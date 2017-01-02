using System;
using System.IO;
using LuaInterface;
using UnityEngine;

public class MsgHandler : IDisposable
{
	private LuaState m_ls = null;
	private LuaFunction m_cmdHander = null;
	
	public static MsgHandler s_instance = null;
	public static MsgHandler Instance
	{
		get 
		{
			if(s_instance == null)
			{
				s_instance = new MsgHandler();
			}
			return s_instance;
		}
	}	
	private MsgHandler() 
    {
        LuaResLoader loader = new LuaResLoader();

        string luaPersistentPath = AppConst.PERSISTENT_PATH + "/lua";
        string[] luaList = Directory.GetFiles(luaPersistentPath);
        for (int i = 0; i < luaList.Length; ++i)
        {
            if (luaList[i].EndsWith(AppConst.AB_EXT_NAME))
            {
                AssetBundle luaAB = AssetBundle.LoadFromFile(luaList[i]);
                if (null != luaAB)
                {
                    loader.AddSearchBundle(Path.GetFileNameWithoutExtension(luaList[i]), luaAB);
                    Debug.Log("lua res loader add search bundle ok:" + Path.GetFileNameWithoutExtension(luaList[i]));
                }
                else
                    Debug.LogError("Load lua AB file error:" + luaList[i]);
            }
        }
    }

	public LuaState GetLuaState() { return m_ls; }

	public bool Init()
	{
		m_ls = new LuaState();
		m_ls.OpenLibs(LuaDLL.luaopen_pb);
		m_ls.LuaSetTop(0); 
		LuaBinder.Bind(m_ls);
		m_ls.Start();

		m_ls.AddSearchPath(AppConst.LUA_TOLUA_PATH);
		m_ls.AddSearchPath(AppConst.LUA_LOGIC_PATH);  
		m_ls.DoFile("LuaMain.lua"); 

		m_cmdHander = m_ls.GetFunction("LuaMain");
		if(null == m_cmdHander)
		{
			Debugger.LogError("lua init failed,LuaMain function not found");
			return false;
		}

        Debugger.Log("CmdHander lua init ok");
		return true;
	}

    public object Require(string luaFileName_)
    {
		int top = m_ls.LuaGetTop();
		string error = null;
		object result = null;

        string relativePath = Path.Combine("Controller", luaFileName_);
		if (m_ls.LuaRequire(relativePath) != 0)
		{
			error = m_ls.LuaToString(-1);
		}
		else
		{
			if(m_ls.LuaGetTop() > top)
			{
				result = m_ls.ToVariant(-1);
			}
		}

		m_ls.LuaSetTop(top);
		
		if (error != null)
		{
			throw new LuaException(error);
		}
		return result;
    }

	public void Dispose()
	{
		if(null != m_cmdHander)
		{
			m_cmdHander.Dispose();
			m_cmdHander = null;
		}

		if(null != m_ls)
		{
			m_ls.Dispose();
			m_ls = null;
		}

		Debugger.Log("CmdHander instance dispose");
	}

    public void MsgParse()
	{
       m_cmdHander.Call();
	}
    /*
    public void LoginToServer()
    {
        LuaFunction loginFunc = m_ls.GetFunction("LoginToServer");
        if (null == loginFunc)
        {
			Debugger.LogError("lua function not found:LoginToServer");
            return;
        }

        loginFunc.Call();
    }*/

}