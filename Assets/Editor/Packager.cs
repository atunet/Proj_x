using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;

public class Packager
{
    //static List<string> paths = new List<string>();
    //static List<string> files = new List<string>();
    static List<AssetBundleBuild> s_abMaps = new List<AssetBundleBuild>();

    // 目录统一不要以'/'结尾
	static string[] s_luaSrcDirs = 
	{ 
		CustomSettings.toluaLuaDir, 
		AppConst.LUA_LOGIC_PATH, 
	};

        
	[MenuItem("Tool/Build iPhone Resource", false, 100)]
    public static void BuildiPhoneResource() 
    {
        BuildAssetResource(BuildTarget.iOS);
    }

	[MenuItem("Tool/Build Android Resource", false, 101)]
    public static void BuildAndroidResource() 
    {
        BuildAssetResource(BuildTarget.Android);
    }

    [MenuItem("Tool/Build Windows Resource", false, 102)]
    public static void BuildWindowsResource() 
    {
        BuildAssetResource(BuildTarget.StandaloneWindows);
    }

    /// <summary>
    /// 生成绑定素材
    /// </summary>
    public static void BuildAssetResource(BuildTarget target_) 
    {
        s_abMaps.Clear();
		PreprocessLuaFiles();
		//PreprocessArtFiles();

		UnityEngine.Debug.Log("BuildAssetResource:" + AppConst.STREAMING_SUB_PATH_PART);
		BuildAssetBundleOptions options = BuildAssetBundleOptions.DeterministicAssetBundle | BuildAssetBundleOptions.UncompressedAssetBundle;
		BuildPipeline.BuildAssetBundles(AppConst.STREAMING_SUB_PATH_PART, s_abMaps.ToArray(), options, target_);
        AssetDatabase.Refresh();
    }
	
    /// <summary>
    /// 预处理Lua代码文件
	/// 循环加密lua文件并输出到临时目录并追加.bytes扩展名
	/// 遍历临时目录中的子目录,添加AssetBundleBuild项,bundle命名规则: lua/lua_subdir.unityid
    /// </summary>
    static void PreprocessLuaFiles() 
    {
		string tempLuaDir = Application.streamingAssetsPath + "/TempLua";
		if(Directory.Exists (tempLuaDir)) 
		{
			Directory.Delete (tempLuaDir, true);
		}
		Directory.CreateDirectory(tempLuaDir);
		AssetDatabase.Refresh();

		for (int i = 0; i < s_luaSrcDirs.Length; i++) 
		{
			string[] fileList = Directory.GetFiles(s_luaSrcDirs[i], "*.lua", SearchOption.AllDirectories);
			for (int k = 0; k < fileList.Length; k++) 
            {
				string subFileName = fileList[k].Substring(s_luaSrcDirs[i].Length);	// "/filename.lua" or "/*/filename.lua"
				string dstFileName = tempLuaDir + subFileName + ".bytes";
				Directory.CreateDirectory(Path.GetDirectoryName(dstFileName));
				EncodeLuaFile(fileList[k], dstFileName);
            }
        }

		string[] subDirList = Directory.GetDirectories(tempLuaDir, "*", SearchOption.AllDirectories);
		for (int i = 0; i < subDirList.Length; i++) 
        {
			string subPart = subDirList[i].Substring(tempLuaDir.Length+1);
			subPart = subPart.Replace('\\', '_').Replace('/', '_');
			string abName = "lua/lua_" + subPart + AppConst.AB_EXT_NAME;

			AddBuildMap(abName, subDirList[i].Substring(AppConst.PROJECT_PATH_LEN), "*.bytes");
        }

		string rootABName = "lua/lua" + AppConst.AB_EXT_NAME;
		AddBuildMap(rootABName, tempLuaDir.Substring(AppConst.PROJECT_PATH_LEN), "*.bytes");
        AssetDatabase.Refresh();
    }

    /// <summary>
    /// 处理框架实例包
    /// </summary>
	static void PreprocessArtFiles() 
	{
        string resPath = "";//AppDataPath + "/" + AppConst.AssetDir + "/";
        if (!Directory.Exists(resPath)) Directory.CreateDirectory(resPath);

        AddBuildMap("prompt" + AppConst.AB_EXT_NAME, "*.prefab", "Assets/LuaFramework/Examples/Builds/Prompt");
		AddBuildMap("message" + AppConst.AB_EXT_NAME, "*.prefab", "Assets/LuaFramework/Examples/Builds/Message");

		AddBuildMap("prompt_asset" + AppConst.AB_EXT_NAME, "*.png", "Assets/LuaFramework/Examples/Textures/Prompt");
		AddBuildMap("shared_asset" + AppConst.AB_EXT_NAME, "*.png", "Assets/LuaFramework/Examples/Textures/Shared");
    }

	static void AddBuildMap(string abName_, string relativePath_, string pattern_) 
	{
		UnityEngine.Debug.Log("AddMap:" + abName_ + "," + relativePath_ + "," + pattern_);

		string[] files = Directory.GetFiles(relativePath_, pattern_);
		if (files.Length == 0) return;

        for (int i = 0; i < files.Length; i++) 
        {
            files[i] = files[i].Replace('\\', '/');
			UnityEngine.Debug.Log("AddMap:" + abName_ + "," + files[i]);
        }

        AssetBundleBuild build = new AssetBundleBuild();
		build.assetBundleName = abName_;
        build.assetNames = files;
        s_abMaps.Add(build);
    }

	public static void EncodeLuaFile(string srcFile_, string outFile_) 
	{
		if (!srcFile_.ToLower().EndsWith(".lua")) 
		{
			File.Copy(srcFile_, outFile_, true);
            return;
        }

		string currDir = Directory.GetCurrentDirectory();
		string exeDir = string.Empty;

		ProcessStartInfo processInfo = new ProcessStartInfo();	
		processInfo.WindowStyle = ProcessWindowStyle.Hidden;
		processInfo.ErrorDialog = true;

        if (Application.platform == RuntimePlatform.WindowsEditor) 
		{
			processInfo.FileName = "luajit.exe";
			processInfo.Arguments = "-b " + srcFile_ + " " + outFile_;
			processInfo.UseShellExecute = true;
			exeDir = AppConst.PROJECT_PATH + "/LuaEncoder/luajit/";
        }
		else if (Application.platform == RuntimePlatform.OSXEditor) 
		{
			processInfo.FileName = "./luac";
			processInfo.Arguments = "-o " + outFile_ + " " + srcFile_;
			processInfo.UseShellExecute = false;
			exeDir = AppConst.PROJECT_PATH + "/LuaEncoder/luavm/";
        }

		Directory.SetCurrentDirectory(exeDir);
		Process.Start(processInfo).WaitForExit();
        Directory.SetCurrentDirectory(currDir);
    }


    /// <summary>
    /// 处理Lua文件
    /// </summary>
    /*
    static void HandleLuaFile() {
        string resPath = AppDataPath + "/StreamingAssets/";
        string luaPath = resPath + "/lua/";

        //----------复制Lua文件----------------
        if (!Directory.Exists(luaPath)) {
            Directory.CreateDirectory(luaPath); 
        }
        string[] luaPaths = { AppDataPath + "/LuaFramework/lua/", 
                              AppDataPath + "/LuaFramework/Tolua/Lua/" };

        for (int i = 0; i < luaPaths.Length; i++) {
            paths.Clear(); files.Clear();
            string luaDataPath = luaPaths[i].ToLower();
            Recursive(luaDataPath);
            int n = 0;
            foreach (string f in files) {
                if (f.EndsWith(".meta")) continue;
                string newfile = f.Replace(luaDataPath, "");
                string newpath = luaPath + newfile;
                string path = Path.GetDirectoryName(newpath);
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                if (File.Exists(newpath)) {
                    File.Delete(newpath);
                }
                if (AppConst.LuaByteMode) {
                    EncodeLuaFile(f, newpath);
                } else {
                    File.Copy(f, newpath, true);
                }
                UpdateProgress(n++, files.Count, newpath);
            } 
        }
        EditorUtility.ClearProgressBar();
        AssetDatabase.Refresh();
    }

    static void BuildFileIndex() {
        string resPath = AppDataPath + "/StreamingAssets/";
        ///----------------------创建文件列表-----------------------
        string newFilePath = resPath + "/files.txt";
        if (File.Exists(newFilePath)) File.Delete(newFilePath);

        paths.Clear(); files.Clear();
        Recursive(resPath);

        FileStream fs = new FileStream(newFilePath, FileMode.CreateNew);
        StreamWriter sw = new StreamWriter(fs);
        for (int i = 0; i < files.Count; i++) {
            string file = files[i];
            string ext = Path.GetExtension(file);
            if (file.EndsWith(".meta") || file.Contains(".DS_Store")) continue;

            string md5 = Util.md5file(file);
            string value = file.Replace(resPath, string.Empty);
            sw.WriteLine(value + "|" + md5);
        }
        sw.Close(); fs.Close();
    }

	///-----------------------------------------------------------
    static string[] exts = { ".txt", ".xml", ".lua", ".assetbundle", ".json" };
    static bool CanCopy(string ext) {   //能不能复制
        foreach (string e in exts) {
            if (ext.Equals(e)) return true;
        }
        return false;
    }

    /// <summary>
    /// 载入素材
    /// </summary>
    static UnityEngine.Object LoadAsset(string file) {
        if (file.EndsWith(".lua")) file += ".txt";
        return AssetDatabase.LoadMainAssetAtPath("Assets/LuaFramework/Examples/Builds/" + file);
    }

    /// <summary>
    /// 数据目录
    /// </summary>
    static string AppDataPath {
        get { return Application.dataPath.ToLower(); }
    }

    /// <summary>
    /// 遍历目录及其子目录
    /// </summary>
    static void Recursive(string path) {
        string[] names = Directory.GetFiles(path);
        string[] dirs = Directory.GetDirectories(path);
        foreach (string filename in names) {
            string ext = Path.GetExtension(filename);
            if (ext.Equals(".meta")) continue;
            files.Add(filename.Replace('\\', '/'));
        }
        foreach (string dir in dirs) {
            paths.Add(dir.Replace('\\', '/'));
            Recursive(dir);
        }
    }

    static void UpdateProgress(int progress, int progressMax, string desc) {
        string title = "Processing...[" + progress + " - " + progressMax + "]";
        float value = (float)progress / (float)progressMax;
        EditorUtility.DisplayProgressBar(title, desc, value);
    }


	[MenuItem("Tool/Build Protobuf-lua-gen File")]
    public static void BuildProtobufFile() {
        if (!AppConst.ExampleMode) {
            Debugger.LogError("若使用编码Protobuf-lua-gen功能，需要自己配置外部环境！！");
            return;
        }

        string dir = AppDataPath + "/Lua/3rd/pblua";
        paths.Clear(); files.Clear(); Recursive(dir);

        string protoc = "d:/protobuf-2.4.1/src/protoc.exe";
        string protoc_gen_dir = "\"d:/protoc-gen-lua/plugin/protoc-gen-lua.bat\"";

        foreach (string f in files) {
            string name = Path.GetFileName(f);
            string ext = Path.GetExtension(f);
            if (!ext.Equals(".proto")) continue;

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = protoc;
            info.Arguments = " --lua_out=./ --plugin=protoc-gen-lua=" + protoc_gen_dir + " " + name;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            info.UseShellExecute = true;
            info.WorkingDirectory = dir;
            info.ErrorDialog = true;
            //Util.Log(info.FileName + " " + info.Arguments);

            Process pro = Process.Start(info);
            pro.WaitForExit();
        }
        AssetDatabase.Refresh();
    }
	*/
}