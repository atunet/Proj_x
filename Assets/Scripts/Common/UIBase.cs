using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Collections;
using LuaInterface;
/*
[ExecuteInEditMode, RequireComponent(typeof(UIPanel))]
public class UIBase : MonoBehaviour
{
    public bool beKeepDepth = false;
    public bool beUseLua = true;
    public bool beUnique = true;

    public Action OnUIClosed = delegate { };

    public static UIBase current = null;

    protected bool beClose = false;

    protected static LinkedList<UIBase> uiList = new LinkedList<UIBase>();
    protected static LinkedList<UIBase> noDepthList = new LinkedList<UIBase>();
    protected static int maxDepth2D = 1;
    protected UIPanel[] panels = null;

    private const int delta = 10;

    protected Transform myTrans = null;
    protected UIPanel panel = null;

    protected static Dictionary<string, AssetRecorder> dict = new Dictionary<string, AssetRecorder>();

    protected LuaState luaState = null;
    protected string moduleName = string.Empty;

    protected bool beSetLuaData = false;
    protected LuaTable self = null;
    private LuaFunction update = null;
    private LuaFunction lateUpdate = null;
    private LuaFunction fixedUpdate = null;
    private bool beStart = false;

    protected List<LuaBaseRef> funcList = new List<LuaBaseRef>();

    public LuaTable table
    {
        get { return self; }
    }

    protected virtual void Init()
    {
        myTrans = transform;
        panel = gameObject.GetComponent<UIPanel>();
        UnGfx.Attach(UI2D.Root, myTrans);

        if (!beKeepDepth)
        {
            panels = gameObject.GetComponentsInChildren<UIPanel>(true);
            Array.Sort<UIPanel>(panels, (p1, p2) => { return p1.depth - p2.depth; });
            AddToList();
        }
        else
        {
            noDepthList.AddLast(this);
        }
    }

    void CallLuaFunction(string name)
    {
        LuaFunction func = luaState.GetFunction(name);

        if (func != null)
        {
            func.BeginPCall();
            func.Push(self);
            func.PCall();
            func.EndPCall();
            func.Dispose();
        }
    }

    protected void Awake()
    {
        luaState = LuaClient.GetMainState();
        name = Utility.RemoveCloneString(name);
        moduleName = name;
        current = this;

        if (beUseLua && Application.isPlaying)
        {
            if (InitLua())
            {
                CallLuaFunction(moduleName + ".Awake");
            }
        }
    }

    protected void Start()
    {
        if (beUseLua && Application.isPlaying)
        {
            InitLua();
            CallLuaFunction(moduleName + ".Start");
            AddUpdate();      
            beStart = true;                
        }
    }

    protected void OnEnable()
    {
        if (beStart)
        {
            AddUpdate();
        }
    }

    protected void OnDisable()
    {
        RemoveUpdate();
    }

    void AddUpdate()
    {
        if (update != null)
        {
            LuaClient.Instance.UpdateEvent.Add(update, self);
        }

        if (lateUpdate != null)
        {
            LuaClient.Instance.LateUpdateEvent.Add(lateUpdate, self);
        }

        if (fixedUpdate != null)
        {
            LuaClient.Instance.FixedUpdateEvent.Add(fixedUpdate, self);
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

    void RemoveUpdate()
    {
        LuaClient inst = LuaClient.Instance;

        if (inst)
        {
            inst.UpdateEvent.Remove(update, self);
            inst.LateUpdateEvent.Remove(lateUpdate, self);
            inst.FixedUpdateEvent.Remove(fixedUpdate, self);
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

    bool InitLua()
    {
        if (!beSetLuaData && luaState != null)
        {
            beSetLuaData = true;
            luaState.Require("UI/" + moduleName);

            self = luaState.GetTable(moduleName);
            update = self.RawGetLuaFunction("Update");            
            lateUpdate = self.RawGetLuaFunction("LateUpdate");
            fixedUpdate = self.RawGetLuaFunction("FixedUpdate");

            if (!beUnique)
            {
                LuaFunction func = self.RawGetLuaFunction("New");
                func.BeginPCall();                
                func.PCall();
                self = func.CheckLuaTable();
                func.EndPCall();
                func.Dispose();                
            }

            self.name = moduleName;
            self["name"] = moduleName;
            SetUserData();           
            return true;
        }

        return false;
    }

    [NoToLuaAttribute]
    public static UIProxy LoadUI(string uiName, Action<UIBase> OnLoad)
    {
        UIProxy proxy = new UIProxy();
        int id = GetAssetID(uiName);

        Action<IAssetFile> action = (file) =>
        {
            UIBase ui = OnLoadUI(file, uiName);
            proxy.uiBase = ui;
            OnLoad(ui);
        };

        AssetFileMgr.Instance.Open(id, action);
        return proxy;
    }

    public static UIProxy LoadUI(string uiName, LuaFunction OnLoad)
    {
        UIProxy proxy = new UIProxy();
        int id = GetAssetID(uiName);
        OnLoad.name = uiName + ".OnLoadUI";

        Action<IAssetFile> action = (file) =>
        {
            UIBase ui = OnLoadUI(file, uiName);
            proxy.uiBase = ui;

            if (ui.self != null)
            {
                OnLoad.BeginPCall();
                OnLoad.Push(ui.self);
                OnLoad.PCall();
                OnLoad.EndPCall();                
            }
            else
            {
                OnLoad.BeginPCall();
                OnLoad.Push(ui);
                OnLoad.PCall();
                OnLoad.EndPCall();                    
            }

            OnLoad.Dispose();
        };

        AssetFileMgr.Instance.Open(id, action);
        return proxy;
    }

    public static UIProxy LoadUI(string uiName)
    {
        UIProxy proxy = new UIProxy();
        int id = GetAssetID(uiName);

        Action<IAssetFile> action = (file) =>
        {
            proxy.uiBase = OnLoadUI(file, uiName);
        };

        AssetFileMgr.Instance.Open(id, action);
        return proxy;
    }

    protected static UIBase OnLoadUI(IAssetFile file, string uiName)
    {
        GameObject go = file.Read<GameObject>(uiName);
        DestroyAsset de = UnGfx.GetSafeComponent<DestroyAsset>(go);
        de.file = file;
        UIBase ui = go.GetComponent<UIBase>();
        ui.moduleName = uiName;
        ui.Init();
        return ui;
    }

    void SetUserData()
    {
        self["gameObject"] = gameObject;
        self["transform"] = transform;
        self["uiBase"] = this;
    }

    //兼容c#和lua，采用c#函数
    public void AddListener(string objName, LuaFunction func)
    {
        Transform node = UnGfx.FindNode(transform, objName);
        UIEventListener listener = UIEventListener.Get(node.gameObject);
        func.name = string.Format("{0}.{1}.OnClick", moduleName , objName);

        UIEventListener.VoidDelegate action = (go) =>
        {
            func.BeginPCall();
            func.Push(go);
            func.PCall();
            func.EndPCall();
        };

        listener.onClick += action;
        funcList.Add(func);
    }

    public void AddListener(string objName, LuaFunction func, LuaTable self)
    {
        Transform node = UnGfx.FindNode(transform, objName);
        UIEventListener listener = UIEventListener.Get(node.gameObject);
        func.name = string.Format("{0}.{1}.OnClick", moduleName, objName);

        UIEventListener.VoidDelegate action = (go) =>
        {
            func.BeginPCall();
            func.Push(self);
            func.Push(go);
            func.PCall();
            func.EndPCall();
        };

        listener.onClick += action;
        funcList.Add(func);
        funcList.Add(self);
    }


    //兼容c#和lua，采用c#函数
    public void AddListenerForInput(string objName, LuaFunction func)
    {
        Transform node = UnGfx.FindNode(transform, objName);
        UIEventListener listener = UIEventListener.Get(node.gameObject);                
        func.name = string.Format("{0}.{1}.OnInput", moduleName, objName);

        UIEventListener.VoidDelegate action = (go) =>
        {
            func.BeginPCall();
            func.Push(go);
            func.PCall();
            func.EndPCall();
        };

        listener.onSubmit += action;
        funcList.Add(func);
    }

    public void AddListenerForInput(string objName, LuaFunction func, LuaTable self)
    {
        Transform node = UnGfx.FindNode(transform, objName);
        UIEventListener listener = UIEventListener.Get(node.gameObject);
        func.name = string.Format("{0}.{1}.OnInput", moduleName, objName);
        

        UIEventListener.VoidDelegate action = (go) =>
        {
            func.BeginPCall();
            func.Push(self);
            func.Push(go);
            func.PCall();
            func.EndPCall();            
        };

        listener.onSubmit += action;
        funcList.Add(func);
        funcList.Add(self);
    }

    public UICenterOnChild.OnCenterCallback VoidDelegateForCenter(LuaFunction func)
    {
        func.name = string.Format("{0}.OnCenter", moduleName);

        UICenterOnChild.OnCenterCallback action = (go) =>
        {
            func.BeginPCall();
            func.Push(go);
            func.PCall();
            func.EndPCall();            
        };

        funcList.Add(func);
        return action;
    }

    public UICenterOnChild.OnCenterCallback VoidDelegateForCenter(LuaFunction func, LuaTable self)
    {
        func.name = string.Format("{0}.OnCenter", moduleName);

        UICenterOnChild.OnCenterCallback action = (go) =>
        {
            func.BeginPCall();
            func.Push(self);
            func.Push(go);
            func.PCall();
            func.EndPCall();                        
        };

        funcList.Add(func);
        return action;
    }


    [NoToLuaAttribute]
    public static int GetAssetID(string uiName)
    {
        AssetRecorder asset = null;

        if (!dict.TryGetValue(uiName, out asset))
        {
            string sql = string.Format("select * from assets where type = 5 and name = 'UI_{0}.unity3d'", uiName);
            asset = TableMgr.Instance.QueryFirst<AssetRecorder>(sql);
            dict.Add(uiName, asset);
        }

        return asset.id;
    }

    //[NoToLuaAttribute]
    //public object[] CallLuaFunc(string funName, params object[] objs)
    //{
    //    string fName = string.Format("{0}.{1}", moduleName, funName);
    //    return CallLuaFunction(fName, objs);
    //}

    public static void DestroyAll()
    {
        foreach (UIBase ui in uiList)
        {
            GameObject go = ui.gameObject;
            ui.beClose = true;
            ui.beUseLua = false;
            ui.OnUIClosed();
            GameObject.Destroy(go);
        }

        foreach (UIBase ui in noDepthList)
        {
            GameObject go = ui.gameObject;
            ui.beClose = true;
            ui.beUseLua = false;
            ui.OnUIClosed();
            GameObject.Destroy(go);
        }

        uiList.Clear();
        noDepthList.Clear();
    }

    public void LogError(string str)
    {
        Type type = this.GetType();
        Debugger.LogError(string.Format("{0} error: {1}", type.Name, str));
    }

    public virtual void Close()
    {        
        CloseInTime(10);
    }

    public virtual void CloseInTime(float time)
    {
        if (!beClose && Application.isPlaying)
        {
            if (beUseLua)
            {
                CallLuaFunction(moduleName + ".OnDestroy");                
            }

            beClose = true;
            OnUIClosed();
            RemoveFromList();
            gameObject.SetActive(false);

            if (time == 0)
            {
                GameObject.Destroy(gameObject);
            }
            else
            {
                GameObject.Destroy(gameObject, time);
            }
        }
    }

    protected virtual void AddToList()
    {
        AddToList(uiList, ref maxDepth2D);
    }

    protected virtual void RemoveFromList()
    {
        RemoveFromList(uiList, ref maxDepth2D, 1);
    }

    protected void AddToList(LinkedList<UIBase> list, ref int depth)
    {
        if (beKeepDepth)
        {
            return;
        }

        if (list.Count > 0)
        {
#if UNITY_EDITOR
            if (list.Find(this) != null)
            {
                Debugger.LogError("UI {0} already in ui list", name);
                return;
            }
#endif
        }

        depth = SetDepth(depth) + delta;
        list.AddLast(this);
    }

    protected void RemoveFromList(LinkedList<UIBase> list, ref int depth, int beginDepth)
    {
        if (beKeepDepth || list.Count == 0)
        {
            noDepthList.Remove(this);
            return;
        }

        list.Remove(this);
        depth = beginDepth;

        foreach (UIBase ui in list)
        {
            depth = ui.SetDepth(depth) + delta;
        }
    }

    int SetDepth(int value)
    {
        int baseLine = panels[0].depth;
        value -= baseLine;

        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].depth += value;
        }

        return panels[panels.Length - 1].depth;
    }

    protected void OnDestroy()
    {
        Close();

        for (int i = 0; i < funcList.Count; i++)
        {
            if (funcList[i] != null)
            {
                funcList[i].Dispose();
            }
        }

        funcList.Clear();

        SafeRelease(ref update);
        SafeRelease(ref lateUpdate);
        SafeRelease(ref fixedUpdate);
        SafeRelease(ref self);                
    }
}*/
