using UnityEngine;
using System.Collections;

public class LoginController : MonoBehaviour 
{
    void Start()
    {
        Debug.Log("login controller start");
    }

	public void OnLoginClick()
	{   
		// show the loading UI ...

        GameObject loadingPrefab = ABManager.Instance.get(AppConst.AB_LOGIN).LoadAsset ("LoadingPrefab") as GameObject;
		if (null == loadingPrefab)
		{
            Debug.LogError("load loadingprefab failed");
            //return;
		}

		//GameObject loadingGo = GameObject.Instantiate (loadingPrefab);
		//loadingGo.transform.SetParent (this.transform.parent);

		// lua init: load the config data and cached role data ...
		if(CmdHandler.Instance.Init())
		{
			NetController.Instance.Connect ();
		}
	}

	public static void InitChapterUI()
	{
	}

    public void OnDestroy()
    {
        Debug.Log("login controller destroy");
    }
}
