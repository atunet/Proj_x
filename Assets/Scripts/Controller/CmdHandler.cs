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
		m_ls.OpenLibs(LuaDLL.luaopen_pb);
		m_ls.LuaSetTop(0); 
		LuaBinder.Bind(m_ls);
		m_ls.Start();

		m_ls.AddSearchPath(AppConst.LUA_TOLUA_PATH);
		m_ls.AddSearchPath(AppConst.LUA_LOGIC_PATH);  
		m_ls.AddSearchPath(AppConst.LUA_PROTO_PATH);		       
		m_ls.DoFile("entry.lua"); 

		m_cmdHander = m_ls.GetFunction("CmdParse");
		if(null == m_cmdHander)
		{
			Debugger.LogError("lua init failed,CmdParse function not found");
			return false;
		}

        Debugger.Log("CmdHander  lua init ok");
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

    public void CmdParse()
	{
       m_cmdHander.Call();
	}

    public void LoginLoginServer()
    {
        LuaFunction loginFunc = m_ls.GetFunction("LoginLoginServer");
        if (null == loginFunc)
        {
			Debugger.LogError("lua function not found:LoginLoginServer");
            return;
        }

        loginFunc.Call();
    }
}