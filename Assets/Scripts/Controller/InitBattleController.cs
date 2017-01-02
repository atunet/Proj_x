using UnityEngine;
using System.Collections;

public class InitBattleController : MonoBehaviour 
{
    void Start () 
    {
        CSBridge.s_uiRoot = GameObject.Find("UIRoot/UICanvas").transform;
        CSBridge.s_sceneRoot = GameObject.Find("SceneRoot/SceneCanvas").transform;
        if (null == CSBridge.s_uiRoot || null == CSBridge.s_sceneRoot)
        {
            Debug.LogError("uiRoot or sceneRoot not found!!!");
            return;
        }

        LuaBehaviour.LuaFileName = "InitBattleBehaviour";
        gameObject.AddComponent<LuaBehaviour>();
    }
}
