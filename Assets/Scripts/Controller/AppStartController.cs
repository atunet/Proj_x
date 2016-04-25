﻿using UnityEngine;
using System.Collections;
using System.IO;

public class AppStartController : MonoBehaviour 
{
    private int m_streamingFileIndex = 0;
    private string[] m_streamingFileList = null;

	private static bool s_resUpdateChecked = false;
	public static void setResChecked(bool checked_) { s_resUpdateChecked = checked_; }


	void Start () 
	{
		AppConst.PrintPath();

		if(!Directory.Exists(AppConst.PERSISTENT_PATH))
        {
			Debug.Log("Init create persistent dir:" + AppConst.PERSISTENT_PATH);
			Directory.CreateDirectory(AppConst.PERSISTENT_PATH);
        }

		if(File.Exists(AppConst.PERSISTENT_VERSION_FILE_PATH))
        {
            CheckResUpdate();
        } 
        else
        {
        	GameObject defaultBG = Resources.Load("defaultBgPrefab") as GameObject;
        	if(null != defaultBG)
        	{
        		GameObject.Instantiate(defaultBG).transform.SetParent(this.transform);
        	}

        	StartCoroutine(InitPersistentFiles());
        }
	}

    void CheckResUpdate()
    {
        AssetBundle loginAB = ABManager.Instance.get(AppConst.AB_LOGIN);
        if (null == loginAB)
        {	
			Debug.LogError("CheckResUpdate failed,login ab file not found");
            return;
        }

        GameObject bgPrefab = loginAB.LoadAsset ("BackgroundPrefab") as GameObject;
		if (null == bgPrefab) 
		{
			Debug.LogError("CheckResUpdate failed,backgroundprefab not found");
		}
		else
		{		
			GameObject bgGo = GameObject.Instantiate (bgPrefab);
			bgGo.transform.SetParent (this.transform.parent);
		}

		if (s_resUpdateChecked) 
		{
            GameObject accountPrefab = loginAB.LoadAsset ("AccountPrefab") as GameObject;
			if (null == accountPrefab)
			{
				// do something to tell player error
				Debug.LogError("CheckResUpdate failed,accountprefab not found");
				return;
			}
			GameObject accountGo = GameObject.Instantiate (accountPrefab);
			accountGo.transform.SetParent (this.transform.parent);
		} 
		else 
		{
            GameObject resUpdatePrefab = loginAB.LoadAsset ("ResUpdatePrefab") as GameObject;
			if (null == resUpdatePrefab)
			{
				// do something to tell player error
				Debug.LogError("CheckResUpdate failed,resourceupdateprefab not found");
				return;
			}			
			GameObject resUpdateGo = GameObject.Instantiate (resUpdatePrefab);
			resUpdateGo.transform.SetParent (this.gameObject.transform);
		}
	}


	private IEnumerator InitPersistentFiles()
	{
		WWW versionWWW = new WWW("file://" + AppConst.STREAMING_VERSION_FILE_PATH);
        yield return versionWWW;

        if (string.IsNullOrEmpty(versionWWW.error))
        {         
            AssetBundle versionAB = versionWWW.assetBundle;
            AssetBundleManifest streamingManifest = versionAB.LoadAsset("AssetBundleManifest") as AssetBundleManifest;

            string[] fileList = streamingManifest.GetAllAssetBundles();
            if (fileList.Length > 0)
            {              
                m_streamingFileList = new string[fileList.Length + 1];
                for (int i = 0; i < fileList.Length; ++i)
                {
                    m_streamingFileList[i] = fileList[i];
                }
                m_streamingFileList[fileList.Length] = AppConst.VERSION_FILE_NAME;
                m_streamingFileIndex = 0;

                streamingManifest = null;
                versionAB.Unload(false);

                versionWWW.Dispose();
                versionWWW = null;

                string streamingFilePath = AppConst.STREAMING_PATH + "/" + m_streamingFileList[m_streamingFileIndex];
                StartCoroutine(CopyFile(streamingFilePath));
            }
            else
                Debug.LogError("streaming manifest file contains nothing");
        }
        else
            Debug.LogError("www load streaming version file failed:" + versionWWW.error + ",file://" + AppConst.STREAMING_VERSION_FILE_PATH);
	}


    private IEnumerator CopyFile(string filePath_)
    {
        WWW w = new WWW("file://" + filePath_);
        yield return w;

        if (string.IsNullOrEmpty(w.error))
        {          
            string relativePath = filePath_.Substring(AppConst.STREAMING_PATH.Length);
            string dstPath = AppConst.PERSISTENT_PATH + relativePath;
            string dirPath = Path.GetDirectoryName(dstPath);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            Debug.Log("Init copy streaming file:" + filePath_.Substring(AppConst.PROJECT_PATH_LEN + 1) + " to " + dstPath + " done, length:" + w.bytes.Length);

            FileStream fs = new FileStream(dstPath, FileMode.Create, FileAccess.ReadWrite);      
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(w.bytes, 0, w.bytes.Length);
            bw.Flush();
            bw.Close(); bw = null;
            fs.Close(); fs = null;
            w.Dispose(); w = null; 

            if (m_streamingFileList.Length > ++m_streamingFileIndex)
            {
                string streamingFilePath = AppConst.STREAMING_PATH + "/" + m_streamingFileList[m_streamingFileIndex];
                StartCoroutine(CopyFile(streamingFilePath));
            }
            else
            {
                if (File.Exists(AppConst.PERSISTENT_VERSION_FILE_PATH))
                {
                    Debug.Log("Init copy all files to persistent path success,total count:" + m_streamingFileIndex + " -------------------------------------------");
                    CheckResUpdate();
                }
                else
                    Debug.LogError("init copy streaming assets done but the version file not found");
            }
        }
        else
            Debug.LogError("init copy file to persistentDataPath failed:file://" + filePath_ + "," + w.error);
    }
}
