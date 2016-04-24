using UnityEngine;
using UnityEditor;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;
using Debug = UnityEngine.Debug;


public class Tool : MonoBehaviour 
{	
	/****************************************************************/
    /********** pack lua && art files to assetbundle files **********/
    /****************************************************************/

	// 需要打包的Lua文件目录列表
	private static string[] s_luaSrcDirs = 
	{ 
		CustomSettings.toluaLuaDir,		// tolua自带的lua库目录 
		AppConst.LUA_LOGIC_PATH, 		// 游戏lua逻辑脚本目录
	};
	private static List<AssetBundleBuild> s_abMaps = new List<AssetBundleBuild>();

	[MenuItem("Tool/Asset Bundle/Build iPhone", false, 100)]
	public static void BuildiPhoneResource() 
	{
		BuildAssetBundle(BuildTarget.iOS);
	}

	[MenuItem("Tool/Asset Bundle/Build Android", false, 101)]
	public static void BuildAndroidResource() 
	{
		BuildAssetBundle(BuildTarget.Android);
	}

	[MenuItem("Tool/Asset Bundle/Build Windows", false, 102)]
	public static void BuildWindowsResource() 
	{
		BuildAssetBundle(BuildTarget.StandaloneWindows);
	}

	[MenuItem("Tool/Asset Bundle/Build Mac", false, 103)]
	public static void BuildMacResource() 
	{
		BuildAssetBundle(BuildTarget.StandaloneOSXIntel);
	}

	/// <summary>
	/// 根据平台打包lua文件和美术资源文件
	/// </summary>
	private static void BuildAssetBundle(BuildTarget target_) 
	{
		if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (target_ == BuildTarget.iOS || target_ == BuildTarget.StandaloneOSXIntel)
            {
                Debug.Log("please build assetbundle in osx system!!!");
                return;
            }
        }
        if (Application.platform == RuntimePlatform.OSXEditor)
        {
            if (target_ == BuildTarget.Android || target_ == BuildTarget.StandaloneWindows)
            {
				Debug.Log("please build assetbundle in windows system!!!");
                return;
            }
        }

		s_abMaps.Clear();
		PreprocessLuaFiles();
		PreprocessArtFiles();

		if (!Directory.Exists (AppConst.STREAMING_PATH)) 
		{
			Directory.CreateDirectory (AppConst.STREAMING_PATH);
			AssetDatabase.Refresh ();
		}
		string relativeOutPath = AppConst.STREAMING_PATH.Substring(AppConst.PROJECT_PATH_LEN + 1);

		BuildAssetBundleOptions options = BuildAssetBundleOptions.DeterministicAssetBundle | BuildAssetBundleOptions.UncompressedAssetBundle;
		BuildPipeline.BuildAssetBundles(relativeOutPath, s_abMaps.ToArray(), options, target_);

		string[] fileList = Directory.GetFiles(AppConst.STREAMING_PATH, "*", SearchOption.TopDirectoryOnly);
		for(int i = 0; i < fileList.Length; ++i)
		{
			string filePath = fileList[i];
            filePath = filePath.Replace("\\", "/");
			string relativePath = filePath.Substring(filePath.LastIndexOf("/"));
			if(relativePath.Contains(AppConst.PLATFORM))
			{
				string newRelativePath = relativePath.Replace(AppConst.PLATFORM, AppConst.VERSION_FILE_NAME);
				string newPath = filePath.Substring(0, filePath.Length-relativePath.Length) + newRelativePath;
                //Debug.Log("path:" + filePath + ",newpath:" + newPath);
                if(File.Exists(newPath)) File.Delete(newPath);
                File.Move(filePath, newPath);
			}
		}

		AssetDatabase.Refresh();
	}

	/// <summary>
	/// 预处理Lua代码文件
	/// 循环加密lua文件并输出到临时目录并追加.bytes扩展名
	/// 遍历临时目录中的子目录,添加AssetBundleBuild项,bundle命名规则: lua/lua_subdir.unityid
	/// </summary>
	static void PreprocessLuaFiles() 
	{
		string tempLuaDir = Application.dataPath + "/TempLua";
		if(Directory.Exists (tempLuaDir)) Directory.Delete (tempLuaDir, true);
		Directory.CreateDirectory(tempLuaDir);
		AssetDatabase.Refresh();

		// encode  /srcdir/xxx.lua to /dstdir/xxx.lua.bytes
		for (int i = 0; i < s_luaSrcDirs.Length; ++i) 
		{
			string thisDir = s_luaSrcDirs[i];
			if(thisDir.EndsWith("\\") || thisDir.EndsWith("/"))
			{
				thisDir = thisDir.Substring(0, thisDir.Length-1);
			}

			string[] fileList = Directory.GetFiles(thisDir, "*.lua", SearchOption.AllDirectories);
			for (int k = 0; k < fileList.Length; ++k) 
			{
				// "/xxx.lua" or "/*/xxx.lua"
				string subName = fileList[k].Substring(thisDir.Length);
				string dstName = tempLuaDir + subName + ".bytes";
				Directory.CreateDirectory(Path.GetDirectoryName(dstName));
				EncodeLuaFile(fileList[k], dstName);
                //UpdateProgress(k++, fileList.Length, "Encoding lua files");
			}
		}

		string[] subDirList = Directory.GetDirectories(tempLuaDir, "*", SearchOption.AllDirectories);
		for (int i = 0; i < subDirList.Length; i++) 
		{
			string subPart = subDirList[i].Substring(tempLuaDir.Length+1);
			subPart = subPart.Replace('\\', '_').Replace('/', '_');
			string abName = "lua/lua_" + subPart.ToLower() + AppConst.AB_EXT_NAME;

			AddBuildMap(abName, subDirList[i].Substring(AppConst.PROJECT_PATH_LEN+1), "*.bytes");
		}
		string rootABName = "lua/lua" + AppConst.AB_EXT_NAME;
		AddBuildMap(rootABName, tempLuaDir.Substring(AppConst.PROJECT_PATH_LEN+1), "*.bytes");

		AssetDatabase.Refresh();
	}

	/// <summary>
	/// 预处理美术资源文件
	/// </summary>
	static void PreprocessArtFiles() 
	{
        EditorUtility.DisplayProgressBar("Set assetbundle name", "Setting assetbundle name ...", 0f);

        string resPath = Application.dataPath + "/Delete";
        string[] dirList = Directory.GetDirectories(resPath, "*", SearchOption.AllDirectories);
        for (int i = 0; i < dirList.Length; ++i)
        {
            string relativeDir = dirList[i].Substring(resPath.Length+1);
            string abName = relativeDir.Replace("\\", "_").Replace("/", "_") + AppConst.AB_EXT_NAME;

            string[] fileList = Directory.GetFiles(dirList[i], "*", SearchOption.TopDirectoryOnly);
            if (0 == fileList.Length) continue;

            int realLength = 0; // 过滤xxx.meta之后的文件数量
            for(int j = 0; j < fileList.Length; ++j)
            {
                if (fileList[j].EndsWith(".meta")) continue;
                realLength++;
            }

            AssetBundleBuild build = new AssetBundleBuild();
            build.assetNames = new string[realLength];
            build.assetBundleName = abName;

            int index = 0;
            for (int k = 0; k < fileList.Length; ++k)
            {             
                if (fileList[k].EndsWith(".meta")) continue;

                string barInfo = "Setting assetbundle:" + abName + "(" + k + "/" + fileList.Length + ")";
                EditorUtility.DisplayProgressBar("Set assetbundle name", barInfo, (float)k / (float)fileList.Length);

                string relativeFilePath = fileList[k].Replace("\\", "/").Substring(AppConst.PROJECT_PATH_LEN+1);
                build.assetNames[index++] = relativeFilePath;
            }

            s_abMaps.Add(build);
        }

        AssetDatabase.Refresh();
        EditorUtility.ClearProgressBar();

        /*
        AddBuildMap("role_login" + AppConst.AB_EXT_NAME, relativePath, "*.prefab");
        AddBuildMap("prompt" + AppConst.AB_EXT_NAME, "*.prefab", "Assets/LuaFramework/Examples/Builds/Prompt");
		AddBuildMap("message" + AppConst.AB_EXT_NAME, "*.prefab", "Assets/LuaFramework/Examples/Builds/Message");
		AddBuildMap("prompt_asset" + AppConst.AB_EXT_NAME, "*.png", "Assets/LuaFramework/Examples/Textures/Prompt");
		AddBuildMap("shared_asset" + AppConst.AB_EXT_NAME, "*.png", "Assets/LuaFramework/Examples/Textures/Shared");
	    */
    }

	static void AddBuildMap(string abName_, string relativePath_, string pattern_) 
	{
		string[] files = Directory.GetFiles(relativePath_, pattern_);
		if (0 == files.Length) return;

		for (int i = 0; i < files.Length; ++i) 
		{
			files[i] = files[i].Replace('\\', '/');
			//Debug.Log("AddMap:" + abName_ + "," + files[i]);
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

		Debug.Log(processInfo.FileName + " " + processInfo.Arguments);
		Directory.SetCurrentDirectory(exeDir);
		Process.Start(processInfo).WaitForExit();
		Directory.SetCurrentDirectory(currDir);
	}

    static void UpdateProgress(int currentNum_, int maxNum_, string title_) 
	{
        string desc = "Processing...[" + currentNum_ + " - " + maxNum_ + "]";
        float value = (float)currentNum_ / (float)maxNum_;
        EditorUtility.DisplayProgressBar(title_, desc, value);
    }

	/****************************************************************/
    /************* upload assetbundle files to web server ***********/
    /****************************************************************/

    [MenuItem("Tool/Upload Resource/Upload Win", false, 200)]
    public static void UploadWinResource()
    {
        UploadResource(BuildTarget.StandaloneWindows);
    }

    [MenuItem("Tool/Upload Resource/Upload Mac", false, 201)]
    public static void UploadMacResource()
    {
        UploadResource(BuildTarget.StandaloneOSXIntel);
    }

    [MenuItem("Tool/Upload Resource/Upload Android", false, 202)]
    public static void UploadAndroidResource()
    {
        UploadResource(BuildTarget.Android);
    }

    [MenuItem("Tool/Upload Resource/Upload IOS", false, 203)]
    public static void UploadIosResource()
    {
        UploadResource(BuildTarget.iOS);
    }

    private static string GetTargetStr(BuildTarget target_)
    {
        if (target_ == BuildTarget.StandaloneWindows)
            return "Windows";
        else if (target_ == BuildTarget.StandaloneOSXIntel)
            return "Mac";
        else if (target_ == BuildTarget.iOS)
            return "iOS";
        else if (target_ == BuildTarget.Android)
            return "Android";
        else
            return "";
    }

    private static void UploadResource (BuildTarget target_)
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (target_ == BuildTarget.iOS || target_ == BuildTarget.StandaloneOSXIntel)
            {
                Debug.Log("please upload ios/osx files from osx system!!!");
                return;
            }
        }
        else if (Application.platform == RuntimePlatform.OSXEditor)
        {
            if (target_ == BuildTarget.Android || target_ == BuildTarget.StandaloneWindows)
            {
				Debug.Log("please upload ios/osx files from windows system!!!");
                return;
            }
        }

        string localDir = AppConst.STREAMING_PATH;
        UpdateProgress(1, 10, "Uploading files to web server");
       
        ProcessStartInfo processInfo = new ProcessStartInfo();  
        processInfo.WindowStyle = ProcessWindowStyle.Hidden;
        processInfo.ErrorDialog = true;

        if (Application.platform == RuntimePlatform.WindowsEditor) 
        {
            processInfo.FileName = "pscp.exe";
            processInfo.Arguments = "-pw sunrise -r " + localDir + " " + "   tfx@" + AppConst.RES_SERVER_IP + ":/var/www/html/res/firework/";
            processInfo.UseShellExecute = true;

            string currDir = Directory.GetCurrentDirectory();
            string exeDir = AppConst.PROJECT_PATH + "/pscp/";

		    Directory.SetCurrentDirectory(exeDir);
			Process.Start(processInfo).WaitForExit();
			Directory.SetCurrentDirectory(currDir);
        }
        else if (Application.platform == RuntimePlatform.OSXEditor) 
        {
            processInfo.FileName = "scp";
            processInfo.Arguments = "-r " + localDir + "   tfx@" + AppConst.RES_SERVER_IP + ":/var/www/html/res/firework/";
            processInfo.UseShellExecute = false;
            Process.Start(processInfo).WaitForExit();
        }

        Debug.Log(processInfo.FileName + " " + processInfo.Arguments);
        EditorUtility.ClearProgressBar();
    }



    /****************************************************************/
    /**************** CSV config file convert to lua ****************/
    /****************************************************************/

	static string s_inputDir = Application.dataPath + "/Config/";
	static string s_outputDir = Application.dataPath + "/Scripts/LuaLogic/config/";
	
	[MenuItem("Tool/Csv To Lua", false, 1)]
	public static void csv2Lua()
	{
		DirectoryInfo dirInfo = new DirectoryInfo(s_inputDir);
		if(!dirInfo.Exists)
		{
			Debug.LogError("Config dir not exists: " + s_inputDir);
			return;
		}		
		
		FileInfo[] fileList = dirInfo.GetFiles("*.csv");
		for(int i = 0; i < fileList.Length; ++i)
		{
			if(fileList[i].Name == "gameOption.csv")
			{
				parseCsvHorizontal(fileList[i].Name);
			}
			else
			{
				parseCsvVertical(fileList[i].Name);
			}
		}
	}
	
	private static void parseCsvHorizontal(string fileName_)
	{
        string inputPath = s_inputDir + fileName_;
        string outputPath = s_outputDir + fileName_.Replace("csv", "lua");

        Debug.Log("input path:" + inputPath);
        Debug.Log("output path:" + outputPath);

        StreamWriter writer = new StreamWriter(outputPath);
        writer.WriteLine(fileName_.Split('.')[0] + " = ");
		writer.WriteLine("{");
		
		string keyName = "id", valueName = "value";
		int keyIndex = 0, valueIndex = 0;
		
        StreamReader reader = new StreamReader(inputPath);		
		
		string line;
		while(null != (line = reader.ReadLine()))
		{
			int offset = 0;
			while(offset < line.Length)
			{
				int startIndex = line.IndexOf('"', offset);
				if(-1 == startIndex) break;
				int endIndex = line.IndexOf('"', startIndex+1);
				if(-1 == endIndex) break;

				//Debug.Log("start:" + startIndex + ",end:" + endIndex);

				string oldStr = line.Substring(startIndex, endIndex-startIndex);
                string newStr = oldStr.Replace(",", ";");
                line = line.Replace(oldStr, newStr);   

                offset = endIndex+1;
			}

            //Debug.Log("line:" + line);

			string[] allFields = line.Split(',');						
			if("" == allFields[0])
			{
				if(allFields.Length < valueIndex+1) 
				{
					Debug.LogWarning("the column count of line not fix the count of key list");
					return;
				}

				string key = allFields[keyIndex];
				string value = allFields[valueIndex];

                value = value.Replace("\"", "");
                value = value.Replace('[', '{');
                value = value.Replace(']', '}');
                string destValue = value;
				
                int round = 0;
                Match m = Regex.Match(value, "\\d{1,2}:\\d{1,2}:\\d{1,2}");
                while(m.Success)
				{
                   // Debug.Log("match value:" + value.Substring(m.Index, m.Length) + "," + m.Index + "," + (m.Index+m.Length));

                    destValue = destValue.Insert(2*round+m.Index, "\"");
                    destValue = destValue.Insert(2*round+m.Index+m.Length+1, "\"");
                    round++;

                    m = m.NextMatch();					
                }

				//if(round > 0) Debug.Log("after deal date:" + destValue);

                destValue = destValue.Replace(";", ",");
                writer.WriteLine("\t" + key + " = " + destValue + ",");
			}	
			else if("!" == allFields[0])
            {
				for(int i = 0; i < allFields.Length; ++i)
                {
					if(allFields[i] == keyName) keyIndex = i;
					else if(allFields[i] == valueName) valueIndex = i;
                }   
                //Debug.Log("keyindex:" + keyIndex + ",valueindex:" + valueIndex);
            }
		}
		
		reader.Close();
		reader = null;
		
		writer.WriteLine("}");
		writer.Close();
		writer = null;
	}
	
	private static void parseCsvVertical(string fileName_)
	{
		string inputPath = s_inputDir + fileName_;
        string outputPath = s_outputDir + fileName_.Replace("csv", "lua");

        Debug.Log("input path:" + inputPath);
        Debug.Log("output path:" + outputPath);

        StreamWriter writer = new StreamWriter(outputPath);
        writer.WriteLine(fileName_.Split('.')[0] + " = ");
		writer.WriteLine("{");
		
		ArrayList keyList = new ArrayList();

        StreamReader reader = new StreamReader(inputPath);		
		
		string line;
		while(null != (line = reader.ReadLine()))
		{
			int offset = 0;
			while(offset < line.Length)
			{
				int startIndex = line.IndexOf('"', offset);
				if(-1 == startIndex) break;
				int endIndex = line.IndexOf('"', startIndex+1);
				if(-1 == endIndex) break;

				//Debug.Log("start:" + startIndex + ",end:" + endIndex);
				string oldStr = line.Substring(startIndex, endIndex-startIndex);
                string newStr = oldStr.Replace(",", ";");
                line = line.Replace(oldStr, newStr);   

                offset = endIndex+1;
			}

           // Debug.Log("line:" + line);

			string[] allFields = line.Split(',');						
			if("" == allFields[0])
			{
				if(allFields.Length != keyList.Count) 
				{
					Debug.LogWarning("the column count of line not fix the count of key list");
					return;
				}

	            string destLine = "\t{ ";
				for(int j = 1; j < allFields.Length; ++j)
	            {
	            	if(keyList[j].Equals("Skip")) continue;

					string field = allFields[j];
					field = field.Replace("\"", "");
					field = field.Replace('[', '{');
					field = field.Replace(']', '}');
	                string destField = field;
					
	                int round = 0;
					Match m = Regex.Match(field, "\\d{1,2}:\\d{1,2}:\\d{1,2}");
	                while(m.Success)
					{
						//Debug.Log("match value:" + field.Substring(m.Index, m.Length) + "," + m.Index + "," + (m.Index+m.Length));

						destField = destField.Insert(2*round+m.Index, "\"");
						destField = destField.Insert(2*round+m.Index+m.Length+1, "\"");
	                    round++;

	                    m = m.NextMatch();					
	                }

					//if(round > 0) Debug.Log("after deal date:" + destField);

					destField = destField.Replace(";", ",");
					if(1 == j)
					{
						destLine += (keyList[j] + " = " + destField);
					}
					else
						destLine += (", " + keyList[j] + " = " + destField);
	            }

                writer.WriteLine(destLine + " },");
			}	
            else if("!" == allFields[0])
            {
				for(int i = 0; i < allFields.Length; ++i)
                {
					keyList.Add(allFields[i]);
					//Debug.Log("key:" + keyList[i]);
                }   
            }
		}
		
		reader.Close();
		reader = null;
		
		writer.WriteLine("}");
		writer.Close();
		writer = null;
	}
}
