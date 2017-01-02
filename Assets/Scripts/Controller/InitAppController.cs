using UnityEngine;
using System.Collections;
using System.IO;

public class InitAppController : MonoBehaviour 
{
    private int m_streamingFileIndex = 0;
    private string[] m_streamingFileList = null;

	private static bool s_resUpdateChecked = false;
	public  static void setResChecked(bool checked_) { s_resUpdateChecked = checked_; }


	void Start () 
	{
        AppConst.PrintPath();

        CSBridge.s_uiRoot = GameObject.Find("UIRoot/UICanvas").transform;
        CSBridge.s_sceneRoot = GameObject.Find("SceneRoot/SceneCanvas").transform;
        if(null == CSBridge.s_uiRoot || null == CSBridge.s_sceneRoot)
        {
            Debug.LogError("uiRoot or sceneRoot not found!!!");
            return;
        }

		if(!Directory.Exists(AppConst.PERSISTENT_PATH))
        {
			Directory.CreateDirectory(AppConst.PERSISTENT_PATH);
        }

		if(File.Exists(AppConst.PERSISTENT_VERSION_FILE_PATH))
        {
            CheckResUpdate();
        } 
        else
        {   // enter game first time, init ...
        	GameObject defaultBG = Resources.Load("default_bg") as GameObject;
        	if(null != defaultBG)
			{	
                GameObject bgGo = GameObject.Instantiate(defaultBG) as GameObject;
                bgGo.transform.SetParent(CSBridge.s_sceneRoot, false);
        	}
            GameObject defaultText = Resources.Load("default_text") as GameObject;
            if(null != defaultText)
            {   
                GameObject textGo = GameObject.Instantiate(defaultText) as GameObject;
                textGo.transform.SetParent(CSBridge.s_uiRoot, false);
            }

        	StartCoroutine(InitPersistentPath());
        }
	}

    void CheckResUpdate()
    {
        Transform bgTrans = CSBridge.s_sceneRoot.FindChild("default_bg(clone)");
        if (bgTrans) GameObject.Destroy(bgTrans.gameObject);
        Transform textTrans = CSBridge.s_uiRoot.FindChild("default_text(clone)");
        if (textTrans) GameObject.Destroy(textTrans.gameObject);

        AssetBundle loginAB = ABManager.get(AppConst.AB_LOGIN);
        if (null == loginAB)
        {	
			Debug.LogError("CheckResUpdate failed,login ab file not found");
            return;
        }
            
        GameObject bgPrefab = loginAB.LoadAsset ("background") as GameObject;
		if (null == bgPrefab) 
		{
			Debug.LogError("CheckResUpdate failed,backgroundprefab not found");
		}
		else
		{		
            bgTrans = GameObject.Instantiate(bgPrefab).transform;
            bgTrans.SetParent(CSBridge.s_sceneRoot, false);
		}

		if (s_resUpdateChecked) 
		{
            GameObject accountPrefab = loginAB.LoadAsset ("account") as GameObject;
			if (null == accountPrefab)
			{
				Debug.LogError("CheckResUpdate failed,accountprefab not found");
				return;
			}
			GameObject accountGo = GameObject.Instantiate (accountPrefab);
            accountGo.transform.SetParent(CSBridge.s_uiRoot, false);

            Destroy(this.gameObject);   // destroy appstartcontroller instance
		} 
		else 
		{
            GameObject resUpdatePrefab = loginAB.LoadAsset ("res_update") as GameObject;
			if (null == resUpdatePrefab)
			{
				Debug.LogError("CheckResUpdate failed,resourceupdateprefab not found");
				return;
			}			
			GameObject resUpdateGo = GameObject.Instantiate (resUpdatePrefab);
            resUpdateGo.transform.SetParent(CSBridge.s_uiRoot, false);
		}
	}


	private IEnumerator InitPersistentPath()
	{
        #if UNITY_ANDROID
        string versionPath = AppConst.STREAMING_VERSION_FILE_PATH;
        #else
        string versionPath = "file://" + AppConst.STREAMING_VERSION_FILE_PATH;
        #endif

        WWW versionWWW = new WWW(versionPath);
        yield return versionWWW;

        if (string.IsNullOrEmpty(versionWWW.error))
        {         
            AssetBundle versionAB = versionWWW.assetBundle;
            AssetBundleManifest abManifest = versionAB.LoadAsset("AssetBundleManifest") as AssetBundleManifest;
            if (null != abManifest)
            {
                string[] fileList = abManifest.GetAllAssetBundles();

                m_streamingFileList = new string[fileList.Length + 1];
                for (int i = 0; i < fileList.Length; ++i)
                {
                    m_streamingFileList[i] = fileList[i];
                }
                m_streamingFileList[fileList.Length] = AppConst.VERSION_FILE_NAME;
                m_streamingFileIndex = 0;

                StartCoroutine(CopyFileToPersistent(AppConst.STREAMING_PATH + "/" + m_streamingFileList[m_streamingFileIndex]));
            }
            else
                Debug.LogError("streaming version file do not contains AssetBundleManifest object");

            abManifest = null;
            versionAB.Unload(true);
        }
        else
            Debug.LogError("www load streaming version file failed:" + versionWWW.error + "," + versionPath);

        versionWWW.Dispose();
        versionWWW = null;
	}


    private IEnumerator CopyFileToPersistent(string filePath_)
    {
        #if !UNITY_ANDROID
        filePath_ = "file://" + filePath_;
        #endif

        WWW w = new WWW(filePath_);
        yield return w;
       
        if (string.IsNullOrEmpty(w.error))
        { 
			#if !UNITY_ANDROID
            string relativePath = filePath_.Substring(AppConst.STREAMING_PATH.Length+7);
			#else
			string relativePath = filePath_.Substring(AppConst.STREAMING_PATH.Length);
			#endif
            string dstPath = AppConst.PERSISTENT_PATH + relativePath;
            string dirPath = Path.GetDirectoryName(dstPath);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

			Debug.Log ("Init copy file:" + filePath_ + "," + relativePath + "," + dstPath);

            FileStream fs = new FileStream(dstPath, FileMode.Create, FileAccess.ReadWrite);      
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(w.bytes, 0, w.bytes.Length);
            bw.Flush();

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
            Debug.LogError("Init copy files to persistent path failed: " + filePath_ + "," + w.error);
    }

    public void OnDestroy()
    {
        Debug.Log("app start controller destroy");
    }
}
