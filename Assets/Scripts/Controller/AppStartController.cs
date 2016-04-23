using UnityEngine;
using System.Collections;
using System.IO;

public class AppStartController : MonoBehaviour 
{
    private int m_streamingFileIndex = 0;
    private string[] m_streamingFileList = null;

	private static AssetBundle s_loginAB = null;
	public static AssetBundle LoginAB { get { return s_loginAB; } }

	private static bool s_resUpdateChecked = false;
	public static void setResChecked(bool checked_) { s_resUpdateChecked = checked_; }


	void Start () 
	{
		AppConst.PrintPath();

		if(!Directory.Exists(AppConst.PERSISTENT_PATH))
        {
			Debug.Log("init create the persistent dir:" + AppConst.PERSISTENT_PATH);
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
        if (null == s_loginAB)
        {
			s_loginAB = AssetBundle.LoadFromFile(AppConst.PERSISTENT_PATH + "/ab_login");
            if (null == s_loginAB) 
            {
				Debug.LogError("CheckResUpdate failed,ab_login file not found");
                return;
            }
        }		

        string[] abFileName = s_loginAB.GetAllAssetNames();
        for(int i = 0; i < abFileName.Length; ++i)
        {
        	Debug.Log(abFileName[i]);
        }

		GameObject bgPrefab = s_loginAB.LoadAsset ("BackgroundPrefab") as GameObject;
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
			GameObject accountPrefab = s_loginAB.LoadAsset ("AccountPrefab") as GameObject;
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
			GameObject resUpdatePrefab = s_loginAB.LoadAsset ("ResUpdatePrefab") as GameObject;
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
		WWW manifestWWW = new WWW("file://" + AppConst.STREAMING_VERSION_FILE_PATH);
		yield return manifestWWW;

		if(!string.IsNullOrEmpty(manifestWWW.error))
		{
            Debug.LogError("init persistent:load streaming version file failed:" + manifestWWW.error);
			yield return 0;
		}

		AssetBundle manifestAB = manifestWWW.assetBundle;
		AssetBundleManifest streamingManifest = manifestAB.LoadAsset("AssetBundleManifest") as AssetBundleManifest;

		string[] fileList = streamingManifest.GetAllAssetBundles();
		if(0 == fileList.Length)
		{
			Debug.LogError("streaming manifest file contains nothing");
			yield return 0;
		}

		m_streamingFileList = new string[fileList.Length+1];
		for(int i = 0; i < fileList.Length; ++i)
		{
		 	m_streamingFileList[i] = fileList[i];
		}
		m_streamingFileList[fileList.Length] = AppConst.VERSION_FILE_NAME;
		m_streamingFileIndex = 0;

        streamingManifest = null;
		manifestAB.Unload(false);

		manifestWWW.Dispose();
		manifestWWW = null;

        string streamingFilePath = AppConst.STREAMING_PATH + "/" + m_streamingFileList[m_streamingFileIndex];
        StartCoroutine(CopyFile(streamingFilePath));
	}


    private IEnumerator CopyFile(string filePath_)
    {
        WWW w = new WWW("file://" + filePath_);
        yield return w;

        if (!string.IsNullOrEmpty(w.error))
        {
            Debug.LogError("init copy file to persistentDataPath failed:" + filePath_ + "," + w.error);
            yield return 0;
        }

        string relativePath = filePath_.Substring(AppConst.STREAMING_PATH.Length);
        string dstPath = AppConst.PERSISTENT_PATH + relativePath;
        string dirPath = Path.GetDirectoryName(dstPath);
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        Debug.Log("init copy streaming file to persistent:" + filePath_ + " done, length:" + w.bytes.Length);
        Debug.Log("init copy streaming file to persistent:" + dstPath);

        FileStream fs = new FileStream(dstPath, FileMode.Create, FileAccess.ReadWrite);      
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Write(w.bytes, 0, w.bytes.Length);
        bw.Flush();
        bw.Close(); bw = null;
        fs.Close(); fs = null;
        w.Dispose(); w = null; 

		if(m_streamingFileList.Length > ++m_streamingFileIndex)
        {
            string streamingFilePath = AppConst.STREAMING_PATH + "/" + m_streamingFileList[m_streamingFileIndex];
            StartCoroutine(CopyFile(streamingFilePath));
        }
        else
        {
            if(File.Exists(AppConst.PERSISTENT_VERSION_FILE_PATH))
            {
            	Debug.Log("all file init copy to persistent success!");
                CheckResUpdate();
			}
			else
            {
                Debug.LogError("init copy streaming assets done but the version file not found");
        	}
        }
    }	
}
