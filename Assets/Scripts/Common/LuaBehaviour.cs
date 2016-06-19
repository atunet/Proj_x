//对于战斗 update 交给脚本管理更方便

using UnityEngine;
using System.Collections;
using System;
using LuaInterface;

public sealed class LuaBehaviour : MonoBehaviour
{
    private string m_luaFileName = null;

    private LuaTable m_self = null;
    private LuaFunction m_updateFunc = null;

  
    protected LuaState      luaState_;
    protected LuaFunction   lupdate_;

    public LuaTable script
    {
        get{ return self_; }
    }

    protected void Awake()
    {
        luaState_ = LuaMainInstance.Instance.luaState;
        if(ScriptName == null)
        {
            Debug.LogError("The ScriptName must be set.");
            return;
        }

        //require lua文件，得到返回的类
        LuaTable metatable = (LuaTable)LuaMainInstance.Instance.require(ScriptName);
        if(metatable == null)
        {
            Debug.LogError("Invalid script file '" + ScriptName + "', metatable needed as a result.");
            return;
        }

        //从类中找到New函数
        LuaFunction lnew = (LuaFunction)metatable["New"];
        if(lnew == null)
        {
            Debug.LogError("Invalid metatable of script '" + ScriptName + "', function 'New' needed.");
            return;
        }

        //执行New函数生成脚本对象
        object[] results = lnew.Call(metatable, this);
        if(results == null || results.Length == 0)
        {
            Debug.LogError("Invalid 'New' method of script '" + ScriptName + "', a return value needed.");
            return;
        }

        //存贮脚本对象
        self_ = (LuaTable)results[0];

        //给脚本对象设置上常用的属性
        self_["transform"] = transform;
        self_["gameObject"] = gameObject;
        self_["behaviour"] = this;

        lupdate_ = (LuaFunction)self_["Update"];

        //尝试调用脚本对象的Awake函数
        CallMethod("Awake");
    }

    // Use this for initialization
    protected void Start ()
    {
        //尝试调用脚本对象的Start函数
        CallMethod("Start");
    }

    // Update is called once per frame
    protected void Update ()
    {
        if(lupdate_ != null)
        {
            lupdate_.Call(self_);
        }
    }

    protected void OnDestroy()
    {
        CallMethod("OnDestroy");

        if(lupdate_ != null)
        {
            lupdate_.Dispose();
            lupdate_ = null;
        }

        //销毁脚本对象
        if(self_ != null)
        {
            self_.Dispose();
            self_ = null;
        }
    }

    protected object[] CallMethod(string func, params object[] args)
    {
        if (self_ == null)
        {
            return null;
        }

        LuaFunction lfunc = (LuaFunction)self_[func];
        if(lfunc == null)
        {
            return null;
        }

        //等价于lua语句: self:func(...)
        int oldTop = lfunc.BeginPCall();
        lfunc.Push(self_);
        lfunc.PushArgs(args);
        lfunc.PCall();
        object[] objs = luaState_.CheckObjects(oldTop);
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
