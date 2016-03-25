using System;
using LuaInterface;

public class CmdHandler : IDisposable
{
	private LuaState m_ls = null;
	private LuaFunction m_cmdHander = null;
	
	public static CmdHandler s_instance = null;
	public static CmdHandler Instance
	{
		get 
		{
			if(s_instance == null)
			{
				s_instance = new CmdHandler();
			}
			return s_instance;
		}
	}
	
	private CmdHandler() {}

	public bool Init()
	{
		m_ls = new LuaState();
		m_ls.Start();
		m_ls.OpenLibs(LuaDLL.luaopen_pb);

		m_ls.BeginModule(null);
		m_ls.BeginStaticLibs("CSNetwork");
		m_ls.RegVar("s_sendProtoId", GetProtoId, SetProtoId);
		m_ls.RegVar("s_sendBytes", GetSendBytes, SetSendBytes);
        m_ls.RegFunction("SendCmd", SendCmd);
        m_ls.EndStaticLibs();
        m_ls.EndModule();

		m_ls.AddSearchPath(AppConst.LUA_TOLUA_PATH);
		m_ls.AddSearchPath(AppConst.LUA_LOGIC_PATH);  
		m_ls.AddSearchPath(AppConst.LUA_PROTO_PATH);		       

		m_ls.DoFile("entry.lua"); 	// load the logic code data
		//m_ls.DoFile("cache.lua");	// load the cached role data 

		m_cmdHander = m_ls.GetFunction("CmdParse");
		if(null == m_cmdHander)
		{
			Debugger.Log("init lua code failed");
			return false;
		}

        Debugger.Log("CmdHander init ok");
		return true;
	}

	public void Dispose()
	{
		m_cmdHander.Dispose();
		m_cmdHander = null;

		m_ls.Dispose();
		m_ls = null;
		
		Debugger.Log("CmdHander instance dispose");
	}

    public void CmdParse(LuaByteBuffer buf_)
	{
        m_cmdHander.Call(buf_);
	}

    public void LoginLoginServer()
    {
        LuaFunction loginFunc = m_ls.GetFunction("LoginLoginServer");
        if (null == loginFunc)
        {
            Debugger.LogError("lua function: loginLoginServer not found");
            return;
        }

        loginFunc.Call();
    }



	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int SendCmd(IntPtr L)
    {
		NetController.Instance.SendCmd(s_sendProtoId, s_sendBytes.buffer);
        return 0;
    }

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetProtoId(IntPtr L)
	{
		ToLua.Push(L, s_sendProtoId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetProtoId(IntPtr L)
	{
		s_sendProtoId = (UInt16)LuaDLL.tolua_tointeger(L, 1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSendBytes(IntPtr L)
	{
		ToLua.Push(L, s_sendBytes);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetSendBytes(IntPtr L)
	{
		s_sendBytes = new LuaByteBuffer(ToLua.CheckByteBuffer(L, 2));
		return 0;
	}

	public static UInt16 s_sendProtoId;
	public static LuaByteBuffer s_sendBytes; 
}