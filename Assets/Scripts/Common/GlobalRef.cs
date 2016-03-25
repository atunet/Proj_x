using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalRef : MonoBehaviour 
{
	// 全局引用
	public static NetLogic s_ml = null;
	public static GlobalRef s_gr = null;

    public GameObject m_playCamera = null;

    public Transform m_uiCanvas = null;
    public Transform m_playCanvas = null;

    //private GameObject m_chapterUIRoot = null;
    private GameObject m_playUIRoot = null; 
    private GameObject m_playRoot = null;

   /* public GameObject ChapterUIRoot
    {
        get { return m_chapterUIRoot; }
        set { m_chapterUIRoot = value; }
    }
*/
    public GameObject PlayUIRoot
    {
        get { return m_playUIRoot; }
        set { m_playUIRoot = value; }
    }

    public GameObject PlayRoot
    {
        get { return m_playRoot; }
        set { m_playRoot = value; }
    }


	/*public static RoleInfo s_ri = new RoleInfo();
    */
	void Start()
	{			
		GameObject NetLogic = GameObject.Find("NetLogic");
		if(NetLogic)
		{
			s_ml = NetLogic.GetComponent<NetLogic>();
			s_gr = NetLogic.GetComponent<GlobalRef>();
			//Object.DontDestroyOnLoad(NetLogic);
		}
		else
		{
			Debug.Log("There is no NetLogic object, please check!");
			Application.Quit();
		}	

		//InitRoleData(); 
	}

	void Update()
	{
		if(Application.platform == RuntimePlatform.Android)
		{
			if(Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Home))
			{
				Debug.Log("key escape or home clicked, app exit!");
				Application.Quit();
			}
		}
	}

    /*
	private void InitRoleData()
	{
		if(HasKey ("AccountId"))
		{
			SceneWelcome.s_accoutId = GetInt ("AccountId");
		}
		else
		{
			SceneWelcome.s_accoutId = NGUITools.RandomRange (10000, 20000);
			SetInt("AccountId", SceneWelcome.s_accoutId);
		}

		if(HasKey ("CreateTime_" + SceneWelcome.s_accoutId))
		{
			s_ri.createTime = GetInt("CreateTime_" + SceneWelcome.s_accoutId);
		}
		else
		{
			s_ri.createTime = SceneLevel.TotalSeconds();
			SetInt("CreateTime_" + SceneWelcome.s_accoutId, s_ri.createTime);
		}

		if(HasKey("CurrentExp_" + SceneWelcome.s_accoutId))
		{
			s_ri.currentExp = GetInt("CurrentExp_" + SceneWelcome.s_accoutId);
		}
		else
		{
			s_ri.currentExp = 0;
			SetInt("CurrentExp_" + SceneWelcome.s_accoutId, s_ri.currentExp);
		}

		if(HasKey("CurrentGold_" + SceneWelcome.s_accoutId))
		{
			s_ri.currentGold = GetInt("CurrentGold_" + SceneWelcome.s_accoutId);
		}
		else
		{
			s_ri.currentGold = 1000;
			SetInt("CurrentGold_" + SceneWelcome.s_accoutId, s_ri.currentGold);
		}

		if(HasKey("CurrentDiamond_" + SceneWelcome.s_accoutId))
		{
			s_ri.currentDiamond = GetInt("CurrentDiamond_" + SceneWelcome.s_accoutId);
		}
		else
		{
			s_ri.currentDiamond = 0;
			SetInt("CurrentDiamond_" + SceneWelcome.s_accoutId, s_ri.currentDiamond);
		}

		if(HasKey("CurrentPower_" + SceneWelcome.s_accoutId))
		{
			s_ri.currentPower = GetInt("CurrentPower_" + SceneWelcome.s_accoutId);
		}
		else
		{
			s_ri.currentPower = 5;
			SetInt("CurrentPower_" + SceneWelcome.s_accoutId, s_ri.currentPower);
		}

		if(HasKey("PowerCountdownTime_" + SceneWelcome.s_accoutId))
		{
			s_ri.powerCountdownTime = GetInt("PowerCountdownTime_" + SceneWelcome.s_accoutId);
		}
		else
		{
			s_ri.powerCountdownTime = 0;
			SetInt("PowerCountdownTime_" + SceneWelcome.s_accoutId, s_ri.powerCountdownTime);
		}

		if(HasKey("CurrentAnimal_" + SceneWelcome.s_accoutId))
		{
			s_ri.currentAnimal = (EAnimal)GetInt("CurrentAnimal_" + SceneWelcome.s_accoutId);
			s_ri.currentAnimal = EAnimal.ANIMAL_CAT;
		}
		else
		{
			s_ri.currentAnimal = EAnimal.ANIMAL_CAT;
			SetInt("CurrentAnimal_" + SceneWelcome.s_accoutId, (byte)s_ri.currentAnimal);
		}
	}

	public static string AbsFilePath(string fileName_)
	{
		return Application.streamingAssetsPath + "/Config/" + fileName_;
	}
	
	void Update()
	{
		if(Application.platform == RuntimePlatform.Android)
		{
			if(Input.GetKey(KeyCode.Escape))
			{
				Debug.Log("Escape key clicked, app exit!");
				Application.Quit();
			}
		}
	}
    */
	public static bool HasKey(string key_)
	{
		return PlayerPrefs.HasKey (key_);
	}

	public static string GetString(string key_)
	{
		return PlayerPrefs.GetString (key_);
	}
	public static int GetInt(string key_)
	{
		return PlayerPrefs.GetInt(key_);
	}
	public static float GetFloat(string key_)
	{
		return PlayerPrefs.GetFloat(key_);
	}

	public static void SetString(string key_, string value_)
	{
		PlayerPrefs.SetString(key_, value_);
	}

	public static void SetInt(string key_, int value_)
	{
		PlayerPrefs.SetInt(key_, value_);
	}

	public static void SetFloat(string key_, float value_)
	{
		PlayerPrefs.SetFloat(key_, value_);
	}
}
