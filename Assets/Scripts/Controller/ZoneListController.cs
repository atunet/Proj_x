using UnityEngine;
using System.Collections;

public class ZoneListController : MonoBehaviour 
{
	public static string s_zoneListURL = "";
	public static string s_selectZoneIP;
	public static ushort s_selectZonePort;
	
	// Use this for initialization
	void Start () 
	{
        Debug.Log("zone list controller start");
		StartCoroutine(LoadZoneList());
	}

	private IEnumerator LoadZoneList()
	{
		WWW zoneListReq = new WWW(s_zoneListURL);
		yield return zoneListReq;

        if(!string.IsNullOrEmpty(zoneListReq.error))
        {
            Debug.LogError("www load zone list failed:" + zoneListReq.error);
           // yield return 0;
		}
        zoneListReq.Dispose();
        zoneListReq = null;


		s_selectZoneIP = "121.199.48.63";
		//s_selectZoneIP = "10.96.29.36";
		s_selectZonePort = 8888;
		//s_selectZonePort = 4444;

		// after select the zone list info, show the login btn ...

		ShowLoginBtn();
	}

	private void ShowLoginBtn()
	{
		GameObject loginBtnPrefab = AppStartController.LoginAB.LoadAsset ("LoginBtnPrefab") as GameObject;
		if (null == loginBtnPrefab)
		{
            Debug.LogError("ShowLoginBtn failed,loginBtnPrefab load failed");
            return;
		}

		GameObject loginBtnGo = GameObject.Instantiate (loginBtnPrefab);
		loginBtnGo.transform.SetParent (this.transform.parent);

		//BGMController btm = BGMController.Instance;
	}
}
