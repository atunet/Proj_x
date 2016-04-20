using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

using SevenZip.Compression.LZMA;


public class ResUpdateController : MonoBehaviour 
{
    private Dictionary<string, Hash128> m_remoteDict = null;
    private Dictionary<string, Hash128> m_localDict = null;
    private List<string> m_downloadList = null;
      
    private float m_totalSize = 0f;
    private float m_currentSize = 0f;
    public Slider m_slider = null;
    
	void Start () 
    {
        Debug.Log("res update controller started");

        m_remoteDict = new Dictionary<string, Hash128>();
        m_localDict = new Dictionary<string, Hash128>();
        m_downloadList = new List<string>();

        StartCoroutine(DownloadManifestFile());
    }

    private IEnumerator DownloadManifestFile()
    {
        WWW manifestWWW = new WWW(AppConst.REMOTE_MANIFEST_FULL_URL);
        yield return manifestWWW;

        if (!string.IsNullOrEmpty(manifestWWW.error))
        {
            Debug.LogError("download manifest file failed:" + AppConst.REMOTE_MANIFEST_FULL_URL + "," + manifestWWW.error);
            yield return 0;
        }

        AssetBundle remoteAB = manifestWWW.assetBundle;
        AssetBundleManifest remoteManifest = remoteAB.LoadAsset("AssetBundleManifest") as AssetBundleManifest;
        ParseManifestFile(remoteManifest, m_remoteDict);
        remoteManifest = null;
        remoteAB.Unload(false);
        manifestWWW.Dispose();
        manifestWWW = null;

        AssetBundle  persistentAB = AssetBundle.LoadFromFile(AppConst.PERSISTENT_VERSION_FILE_PATH);
        if(null == persistentAB)
        {
			Debug.LogError("ResUpdate:load persistent manifest file failed:" + AppConst.PERSISTENT_VERSION_FILE_PATH);
            yield return 0;
        }

        AssetBundleManifest persistentManifest = persistentAB.LoadAsset("AssetBundleManifest") as AssetBundleManifest;
        ParseManifestFile(persistentManifest, m_localDict);
        persistentManifest = null;
        persistentAB.Unload(false);           

        CompareManifestFile();
        if(m_downloadList.Count > 0) 
        {
            m_downloadList.Add(AppConst.VERSION_FILE_NAME);
            m_totalSize++;
        }
        StartCoroutine(DownloadAssetBundles());
    }

    private void ParseManifestFile(AssetBundleManifest abm_, Dictionary<string, Hash128> dict_)
    {
        if (abm_ == null) return;
        
        string[] abList = abm_.GetAllAssetBundles();
        foreach(string abName in abList)
        {
            Debug.Log("ParseManifestFile add[" + abName + "," + abm_.GetAssetBundleHash(abName) +"]");
            dict_.Add(abName, abm_.GetAssetBundleHash(abName));            
        }
    }

    private void CompareManifestFile()
    {
        foreach (KeyValuePair<string, Hash128> kv in m_remoteDict)
        {
            string abName = kv.Key;
            Hash128 remoteHash = kv.Value;
       
            Hash128 localHash;      
            if(!m_localDict.TryGetValue(abName, out localHash) 
            || !remoteHash.Equals(localHash))
            {
                m_downloadList.Add(abName);
                m_totalSize += 1f;
                
                Debug.Log("CompareManifestFile, download list add: " + abName);
            }
        }
    }

    private IEnumerator DownloadAssetBundles()
    {    
        if(m_downloadList.Count == 0)
        {
			AppStartController.setResChecked(true);
			Application.LoadLevel(Application.loadedLevelName);
            yield return 0;
        }
        
        string abName = m_downloadList[0];
        m_downloadList.RemoveAt(0);

        string abFileURL = Path.Combine(AppConst.REMOTE_ASSET_URL, abName);
        WWW abWWW = new WWW(abFileURL);
        yield return abWWW;

        if (!string.IsNullOrEmpty(abWWW.error))
        {
            Debug.LogError("download ab file failed:" + abFileURL + "," + abWWW.error);
            yield return 0;
        }

        ReplaceLocalFile(abName, abWWW.bytes);
        m_currentSize += 1f;

        StartCoroutine(DownloadAssetBundles());
    }
    
    private void ReplaceLocalFile(string abName_, byte[] data_)
    {
		FileStream fs = new FileStream(Path.Combine(AppConst.PERSISTENT_PATH, abName_), FileMode.Create);
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Write(data_, 0, data_.Length);
        bw.Flush();
        bw.Close(); bw = null;
        fs.Close(); fs = null;
    }
    
    public void Update ()
    {
        if (null == m_slider) return;
        
        if (m_slider.gameObject.activeSelf && m_totalSize > 0)
        {
            m_slider.value = m_currentSize / m_totalSize;
            
            Debug.Log("slider value:" + m_slider.value);
        }
    }
}
