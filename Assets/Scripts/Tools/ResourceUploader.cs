using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Net;
using System.IO;

public class ResourceUploader : MonoBehaviour
 {
    private Dictionary<string, Hash128> m_localDict = null;
    private Dictionary<string, Hash128> m_remoteDict = null;
    private List<string> m_uploadList = null;

    private float m_totalSize = 0f;
    private float m_currentSize = 0f;

	void Start () 
	{		
        m_localDict = new Dictionary<string, Hash128>();
        m_remoteDict = new Dictionary<string, Hash128>();
        m_uploadList = new List<string>();

        if (ReadLocalManifest())
        {
            StartCoroutine(DownloadRemoteManifest());
        }
	}
        
    bool ReadLocalManifest()
    {
        string localManifestPath = Path.Combine(AppConst.STREAMING_PATH,  AppConst.VERSION_FILE_NAME);

        AssetBundle localManifestAB = AssetBundle.LoadFromFile(localManifestPath);
        if (null == localManifestAB)
        {
            Debug.LogError("load local manifest file failed:" + localManifestPath);
            return false;
        }

        AssetBundleManifest localManifest = localManifestAB.LoadAsset("AssetBundleManifest") as AssetBundleManifest;
        ParseManifestFile(localManifest, m_localDict);
            
        localManifest = null;
        localManifestAB.Unload(false);

        return true;
    }


    private void ParseManifestFile(AssetBundleManifest abm_, Dictionary<string, Hash128> dict_)
    {
        if (abm_ == null) return;

        string[] abList = abm_.GetAllAssetBundles();
        foreach(string abName in abList)
        {
            dict_.Add(abName, abm_.GetAssetBundleHash(abName));

            Debug.Log("ParseManifestFile add[" + abName + "," + abm_.GetAssetBundleHash(abName) +"]");
        }
    }

	
    IEnumerator DownloadRemoteManifest()
    {
        string remoteManifestPath = Path.Combine(AppConst.REMOTE_ASSET_URL, AppConst.VERSION_FILE_NAME);
        WWW manifestWWW = new WWW(remoteManifestPath);
		yield return manifestWWW;

        if (string.IsNullOrEmpty(manifestWWW.error))
        {
            AssetBundle remoteManifestAB = manifestWWW.assetBundle;
            AssetBundleManifest remoteManifest = remoteManifestAB.LoadAsset("AssetBundleManifest") as AssetBundleManifest;
            ParseManifestFile(remoteManifest, m_remoteDict);

            remoteManifest = null;
            remoteManifestAB.Unload(false);
        }
        else    // maybe this is the first time to uplad
		{   
            Debug.LogWarning("download remote manifest file failed:" + manifestWWW.error + "," + remoteManifestPath); 
		}	   

        CompareManifestFile();
        UploadResource();
    }


    private void CompareManifestFile()
    {
        foreach (KeyValuePair<string, Hash128> kv in m_localDict)
        {
            string abName = kv.Key;
            Hash128 localHash = kv.Value;

            Hash128 remoteHash;      
            if(!m_remoteDict.TryGetValue(abName, out remoteHash) 
                || !remoteHash.Equals(localHash))
            {
                m_uploadList.Add(abName);
                m_totalSize += 1f;

                Debug.Log("CompareManifestFile, upload list add: " + abName);
            }
        }

        // add the manifest file 
        m_uploadList.Add(AppConst.VERSION_FILE_NAME);
        m_totalSize += 1f;
    }

	void UploadResource ()
    {
        string fileName = m_uploadList[0];
        m_uploadList.RemoveAt(0);

        FileStream fs = File.OpenRead(Path.Combine(AppConst.STREAMING_PATH, fileName));
        byte[] fileBytes = new byte[fs.Length];
        fs.Read(fileBytes, 0, fileBytes.Length);
        fs.Close();

        string remoteFilePath = AppConst.UPLOAD_ASSET_URL + "/" + fileName;
        Debug.Log("remote file:" + remoteFilePath);
      
        FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(remoteFilePath);
        req.Method = WebRequestMethods.Ftp.UploadFile;
        req.Credentials = new NetworkCredential("tfx", "sunrise");
        req.ContentLength = fileBytes.Length;
        req.KeepAlive = true;
        req.UseBinary = true;
        req.Timeout = 50*1000;

        Stream ftpStream = req.GetRequestStream();
        ftpStream.Write(fileBytes, 0, fileBytes.Length);
        ftpStream.Dispose();
        ftpStream = null;

        Debug.Log("upload file done:" + fileName);

        if (m_uploadList.Count > 0)
        {
            UploadResource();
        } 
    }
}
