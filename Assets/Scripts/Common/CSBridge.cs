using System;
using UnityEngine;
using UnityEngine.UI;
using LuaInterface;

public sealed class CSBridge
{
    public static Transform s_uiRoot = null;
    public static Transform s_sceneRoot = null;
    public static Transform UIRoot() { return s_uiRoot; }
    public static Transform SceneRoot() { return s_sceneRoot; }

	public static int s_recvProtoId = 0;
	public static LuaByteBuffer s_recvBytes = null;

	public static int s_sendProtoId = 0;
	public static LuaByteBuffer s_sendBytes = null; 

	public static bool SendMsg()
	{
        return NetController.Instance.SendMsgToGate((Cmd.EMessageID)s_sendProtoId, s_sendBytes.buffer);
	}

    public static bool SendMsgToCross()
    {
        return NetController.Instance.SendMsgToCross((Cmd.EMessageID)s_sendProtoId, s_sendBytes.buffer);
    }

    public static LuaTable AddComponent(GameObject go_, string luaFileName_)
    {
    	LuaBehaviour.LuaFileName = luaFileName_;
    	return go_.AddComponent<LuaBehaviour>().LuaTable();
    }

	public static void AddClick(Button btn_, LuaFunction func_) 
	{
    	if (btn_ == null || func_ == null) 
    	{
    		Debug.LogWarning("addclick failed,btn or func is null");
    		return;
        }
        btn_.onClick.AddListener(delegate() { func_.Call(btn_.gameObject); });
    }

    public static void LoadLevel(string levelName_)
    {
        InitLoadingController.setNextScene(levelName_);
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
