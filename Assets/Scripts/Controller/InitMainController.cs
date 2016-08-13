using UnityEngine;
using System.Collections;

public class InitMainController : MonoBehaviour 
{
	void Start () 
    {
        CSInterface.s_uiRoot = GameObject.Find("UIRoot/UICanvas").transform;
        CSInterface.s_sceneRoot = GameObject.Find("SceneRoot/SceneCanvas").transform;
        if (null == CSInterface.s_uiRoot || null == CSInterface.s_sceneRoot)
        {
            Debug.LogError("uiRoot or sceneRoot not found!!!");
            return;
        }

        LuaBehaviour.LuaFileName = "InitMainBehaviour";
        gameObject.AddComponent<LuaBehaviour>();
	}
}
