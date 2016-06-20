using UnityEngine;
using System.Collections;
using System;
using LuaInterface;

public sealed class LuaBehaviour : MonoBehaviour
{
    private static string s_luaFileName = null;

    private LuaTable m_self = null;
    private LuaFunction m_luaUpdate = null;
    private LuaFunction m_luaFixedUpdate = null;
    private LuaFunction m_luaLateUpdate = null;
    private LuaFunction m_luaDestroy = null;

    public static string LuaFileName
    {
        get { return s_luaFileName; }
        set { s_luaFileName = value; }
    }

    protected void Awake()
    {
        LuaTable metatable = CmdHandler.Instance.Require(s_luaFileName);
        if(metatable == null)
        {
            Debug.LogError("[LuaBehaviour] require lua file failed: " + s_luaFileName);
            return;
        }

        LuaFunction newFunc = (LuaFunction)metatable["New"];
        if(newFunc == null)
        {
            Debug.LogError("[LuaBehaviour] load 'New' lua function failed: " + s_luaFileName);
            return;
        }

        //执行New函数生成脚本对象
        object[] res = newFunc.Call(metatable, this);
        if(res == null || res.Length == 0)
        {
            Debug.LogError("[LuaBehaviour] 'New' function should return a table instance: " + s_luaFileName);
            return;
        }

        m_self = (LuaTable)res[0];

        //给脚本对象设置上常用的属性
        m_self["transform"] = transform;
        m_self["gameObject"] = gameObject;
        m_self["behaviour"] = this;

        m_luaUpdate = (LuaFunction)m_self["Update"];
        m_luaFixedUpdate = (LuaFunction)m_self["FixedUpdate"];
        m_luaLateUpdate = (LuaFunction)m_self["LateUpdate"];
        m_luaDestroy = (LuaFunction)m_self["Destroy"];

     	CallMethod("Awake");
    }

    // Use this for initialization
    protected void Start ()
    {
    	CallMethod("Start");
    }

    // Update is called once per frame
    protected void Update ()
    {
        if(m_luaUpdate != null)
        {
            m_luaUpdate.Call(m_self);
        }
    }

    protected void OnDestroy()
    {
    	CallMethod("OnDestroy");

        if(m_luaUpdate != null)
        {
            m_luaUpdate.Dispose();
            m_luaUpdate = null;
        }

		if(m_luaFixedUpdate != null)
        {
			m_luaFixedUpdate.Dispose();
			m_luaFixedUpdate = null;
        }

		if(m_luaLateUpdate != null)
        {
			m_luaLateUpdate.Dispose();
			m_luaLateUpdate = null;
        }

        if(m_self != null)
        {
            m_self.Dispose();
            m_self = null;
        }
    }

    protected object[] CallMethod(string func, params object[] args)
    {
        if (m_self == null)
        {
            return null;
        }

        LuaFunction lfunc = (LuaFunction)m_self[func];
        if(lfunc == null)
        {
            return null;
        }

        //等价于lua语句: self:func(...)
        int oldTop = lfunc.BeginPCall();
        lfunc.Push(m_self);
        lfunc.PushArgs(args);
        lfunc.PCall();
        object[] objs = null;//luaState_.CheckObjects(oldTop);
        lfunc.EndPCall();
        return objs;
    }
}

/*
public class LuaBehaviour : MonoBehaviour
{
    [NoToLuaAttribute]
    public bool createInCS = false;
    [NoToLuaAttribute]
    public string luaFile = null;
    [NoToLuaAttribute]
    public string tableName = null;
    [NoToLuaAttribute]
    public bool unique = true;

    protected LuaFunction LuaNew = null;
    protected LuaFunction LuaAwake = null;
    protected LuaFunction LuaStart = null;
    protected LuaFunction LuaOnDestroy = null;

    protected LuaFunction LuaOnTriggerEnter = null;
    protected LuaFunction LuaOnTriggerExit = null;

    protected LuaTable self = null;
    private LuaState luaState = null;    

    public virtual void SetLuaTable(LuaTable table)
    {
        if (self == null)
        {
            self = table;
            self.name = tableName != null ? tableName : gameObject.name;
        }

        if (self != null)
        {
            LuaAwake = self.GetLuaFunction("Awake") as LuaFunction;
            LuaStart = self.GetLuaFunction("Start") as LuaFunction;
            LuaOnDestroy = self.GetLuaFunction("OnDestroy") as LuaFunction;
            LuaOnTriggerEnter = self.GetLuaFunction("OnTriggerEnter") as LuaFunction;
            LuaOnTriggerExit = self.GetLuaFunction("OnTriggerExit") as LuaFunction;
        }
    }

    protected void Awake()
    {
        luaState = LuaClient.GetMainState();

        if (createInCS && luaState != null)
        {            
            luaState.Require(luaFile);
            self = luaState.GetTable(tableName);

            if (!unique)
            {
                LuaNew = self.GetLuaFunction("New");                                
                LuaNew.BeginPCall();                
                LuaNew.PCall();
                SafeRelease(ref self);
                self = LuaNew.CheckLuaTable();
                self.name = tableName;
                LuaNew.EndPCall();                                
            }

            self["gameObject"] = gameObject;
            self["this"] = this;
            SetLuaTable(self);

            if (LuaAwake != null)
            {
                LuaAwake.BeginPCall();
                LuaAwake.Push(self);
                LuaAwake.PCall();
                LuaAwake.EndPCall();
            }            
        }        
    }

    protected void SafeRelease(ref LuaFunction func)
    {
        if (func != null)
        {
            func.Dispose();
            func = null;
        }
    }

    protected void SafeRelease(ref LuaTable table)
    {
        if (table != null)
        {
            table.Dispose();
            table = null;
        }
    }

    protected void Release()
    {
        SafeRelease(ref LuaNew);
        SafeRelease(ref LuaAwake);
        SafeRelease(ref LuaStart);
        SafeRelease(ref LuaOnDestroy);
        SafeRelease(ref LuaOnTriggerEnter);
        SafeRelease(ref LuaOnTriggerExit);

        //SafeRelease(ref update);
        //SafeRelease(ref lateUpdate);
        //SafeRelease(ref fixedUpdate);
        SafeRelease(ref self);   
    }

    protected void Start()
    {
        if (LuaStart != null)
        {
            LuaStart.BeginPCall();
            LuaStart.Push(self);
            LuaStart.PCall();
            LuaStart.EndPCall();            
        }

        //beStart = true;
        //AddUpdate();
    }

    protected void OnDestroy()
    {
        if (LuaOnDestroy != null && luaState != null)
        {
            LuaOnDestroy.BeginPCall();
            LuaOnDestroy.Push(self);
            LuaOnDestroy.PCall();
            LuaOnDestroy.EndPCall();            
            Release();
        }
    }

    protected void OnApplicationQuit()
    {
        LuaOnDestroy = null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (LuaOnTriggerEnter != null)
        {
            LuaOnTriggerEnter.BeginPCall();
            LuaOnTriggerEnter.Push(self);
            LuaOnTriggerEnter.Push(other);
            LuaOnTriggerEnter.PCall();
            LuaOnTriggerEnter.EndPCall();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (LuaOnTriggerExit != null)
        {
            LuaOnTriggerExit.BeginPCall();
            LuaOnTriggerExit.Push(self);
            LuaOnTriggerExit.Push(other);
            LuaOnTriggerExit.PCall();
            LuaOnTriggerExit.EndPCall();
        }
    }
}
*/
