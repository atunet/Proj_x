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
        yield return new WaitForSeconds(2f);

		// after account login, load the zone list UI ...
        AssetBundle loginAB = ABManager.Instance.get(AppConst.AB_LOGIN);
        if (null != loginAB)
        {
            GameObject zongListPrefab = loginAB.LoadAsset("zone_list") as GameObject;
            if (null != zongListPrefab)
            {
                GameObject zoneListGo = GameObject.Instantiate(zongListPrefab);
                zoneListGo.transform.SetParent(CSInterface.s_uiRoot);
                zoneListGo.transform.localPosition = new Vector3(0f, -425f, 0f);
                zoneListGo.transform.localScale = new Vector3(1f, 1f, 1f);

                Destroy(this.gameObject);   // destroy account controller instance
            }
        }
	}

    public void OnDestroy()
    {
        Debug.Log("account controller destroy");
    }
}
