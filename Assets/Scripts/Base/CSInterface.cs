using System;
using UnityEngine;
using UnityEngine.UI;
using LuaInterface;

public sealed class CSInterface
{
    public static Transform s_uiRoot = null;
    public static Transform s_sceneRoot = null;

	public static int s_recvProtoId = 0;
	public static LuaByteBuffer s_recvBytes = null;

	public static int s_sendProtoId = 0;
	public static LuaByteBuffer s_sendBytes = null; 

	public static bool SendCmd()
	{
		return NetController.Instance.SendCmd((UInt16)s_sendProtoId, s_sendBytes.buffer);
	}

	public static void SetServerAddr(string ip_, ushort port_)
	{
		NetController.Instance.ServerIP = ip_;
		NetController.Instance.ServerPort = port_;

		Debugger.Log("Set new server addr:[" + ip_ + ":" + port_ + "]");
	}

	public static byte GetServerType()
	{
		return NetController.Instance.ServerType;
	}

	public static void SetServerType(byte type_)
	{
		NetController.Instance.ServerType = type_;
	}

	public static void DisconnectToServer()
	{
		NetController.Instance.Reset();
	}

	public static void LoginToServer()
	{
		NetController.Instance.Connect();
	}
    public static Transform UIRoot()
    {
        return s_uiRoot;
    }
    public static Transform SceneRoot()
    {
        return s_sceneRoot;
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
