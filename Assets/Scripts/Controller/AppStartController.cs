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
			Directory.CreateDirectory(AppConst.PERSISTENT_PATH);
        }

		if(File.Exists(AppConst.PERSISTENT_VERSION_FILE_PATH))
        {
            CheckResUpdate();
        } 
        else
        {
        	GameObject defaultBG = Resources.Load("defaultBGPrefab") as GameObject;
        	if(null != defaultBG)
			{	
                GameObject bgGo = GameObject.Instantiate(defaultBG) as GameObject;
                bgGo.transform.SetParent(GameObject.Find("UIRoot/UICanvas").transform);
                bgGo.transform.localPosition = new Vector3(0f, 0f, 0f);
                bgGo.transform.localScale = new Vector3(1f, 1f, 1f);
        	}
            GameObject defaultText = Resources.Load("defaultTextPrefab") as GameObject;
            if(null != defaultText)
            {   
                GameObject textGo = GameObject.Instantiate(defaultText) as GameObject;
                textGo.transform.SetParent(GameObject.Find("UIRoot/UICanvas").transform);
                textGo.transform.localPosition = new Vector3(0f, -425f, 0f);
                textGo.transform.localScale = new Vector3(1f, 1f, 1f);
            }

        	StartCoroutine(InitPersistentFiles());
        }
	}

    void CheckResUpdate()
    {
        GameObject bgGo = GameObject.Find("UIRoot/UICanvas/defaultBGPrefab(clone)");
        if (bgGo) GameObject.Destroy(bgGo);

        GameObject textGo = GameObject.Find("UIRoot/UICanvas/defaultTextPrefab(clone)");
        if (textGo) GameObject.Destroy(textGo);

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
			bgGo = GameObject.Instantiate (bgPrefab);
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
			resUpdateGo.transform.SetParent (this.transform.parent);
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
            if(null != streamingManifest)
            {
            	string[] fileList = streamingManifest.GetAllAssetBundles();
                        
                m_streamingFileList = new string[fileList.Length + 1];
                for (int i = 0; i < fileList.Length; ++i)
                {
                    m_streamingFileList[i] = fileList[i];
                }
                m_streamingFileList[fileList.Length] = AppConst.VERSION_FILE_NAME;
                m_streamingFileIndex = 0;

                streamingManifest = null;
                versionAB.Unload(true);

                versionWWW.Dispose();
                versionWWW = null;

				StartCoroutine(CopyFileToPersistent(AppConst.STREAMING_PATH + "/" + m_streamingFileList[m_streamingFileIndex]));
            }
            else
                Debug.LogError("streaming version file do not contains AssetBundleManifest object");
        }
        else
            Debug.LogError("www load streaming version file failed:" + versionWWW.error + ",file://" + AppConst.STREAMING_VERSION_FILE_PATH);
	}


    private IEnumerator CopyFileToPersistent(string filePath_)
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

            FileStream fs = new FileStream(dstPath, FileMode.Create, FileAccess.ReadWrite);      
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(w.bytes, 0, w.bytes.Length);
            bw.Flush();
			Debug.Log("Init copy streaming file:" + filePath_.Substring(AppConst.PROJECT_PATH_LEN + 1) + " to " + dstPath + " done,length:" + w.bytes.Length);

            bw.Close(); bw = null;
            fs.Close(); fs = null;
            w.Dispose(); w = null; 

            if (m_streamingFileList.Length > ++m_streamingFileIndex)
            {
				StartCoroutine(CopyFileToPersistent(AppConst.STREAMING_PATH + "/" + m_streamingFileList[m_streamingFileIndex]));
            }
            else
            {
                if (File.Exists(AppConst.PERSISTENT_VERSION_FILE_PATH))
                {
                    Debug.Log("Init copy files to persistent path success,total count: " + m_streamingFileIndex + " -------------------------------------------");
                    CheckResUpdate();
                }
                else
                    Debug.LogError("Init copy streaming files done but the version file still not found");
            }
        }
        else
            Debug.LogError("Init copy files to persistent path failed,file: file://" + filePath_ + "," + w.error);
    }
}
