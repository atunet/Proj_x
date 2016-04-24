using UnityEngine;
using System.Collections;

public class AccountController : MonoBehaviour 
{
	private static string s_userName = "abc";
	private static string s_userPswd = "123456";

	// Use this for initialization
	void Start () 
	{
        Debug.Log("account controller start");

		StartCoroutine(AccountLogin());
	}

	IEnumerator AccountLogin()
	{
		// TODO ... account reg or account login to other platform ...

		// after account login, load the zone list UI ...
        AssetBundle loginAB = ABManager.Instance.get(AppConst.AB_LOGIN);
        if (null == loginAB)
        {
            yield return 0;
        }

        GameObject zongListPrefab = loginAB.LoadAsset ("ZoneListPrefab") as GameObject;
		if (null == zongListPrefab)
		{
			// do something to tell player error
			yield return 0;
		}
		GameObject zoneListGo = GameObject.Instantiate (zongListPrefab);
		zoneListGo.transform.SetParent (this.transform.parent);
	}
}
