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
	// Lua打包的目录列表
	// 目录名务必不要以'\'或者'/'结尾
	static string[] s_luaSrcDirs = 
	{ 
		CustomSettings.toluaLuaDir,	// tolua自带的lua目录 
		AppConst.LUA_LOGIC_PATH, 	// 游戏lua脚本目录
	};
	static List<AssetBundleBuild> s_abMaps = new List<AssetBundleBuild>();

	/*
	[MenuItem ("Tool/AssetBundle/Build Win")]
	static void BuildAllAssetBundles_pc ()
	{
		Debug.Log("build assetbundles to:" + AppConst.STREAMING_ASSETS_PATH + " done");
		BuildPipeline.BuildAssetBundles (AppConst.STREAMING_ASSETS_PATH, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
	}

	[MenuItem ("Tool/AssetBundle/Build Mac")]
	static void BuildAllAssetBundles_mac ()
	{
		Debug.Log("build assetbundles to:" + AppConst.STREAMING_ASSETS_PATH + " done");
		BuildPipeline.BuildAssetBundles (AppConst.STREAMING_ASSETS_PATH, BuildAssetBundleOptions.None, BuildTarget.StandaloneOSXIntel64);
	}

	[MenuItem ("Tool/AssetBundle/Build Ios")]
	static void BuildAllAssetBundles_ios ()
	{        
		Debug.Log("build assetbundles to:" + AppConst.STREAMING_ASSETS_PATH + " done");
		BuildPipeline.BuildAssetBundles (AppConst.STREAMING_ASSETS_PATH, BuildAssetBundleOptions.None, BuildTarget.iOS);
	}

	[MenuItem ("Tool/AssetBundle/Build Android")]
	static void BuildAllAssetBundles_android ()
	{
		Debug.Log("build assetbundles to:" + AppConst.STREAMING_ASSETS_PATH + " done");
		BuildPipeline.BuildAssetBundles (AppConst.STREAMING_ASSETS_PATH, BuildAssetBundleOptions.None, BuildTarget.Android);
	}
*/
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
		s_abMaps.Clear();
		PreprocessLuaFiles();
		PreprocessArtFiles();

		string absOutPath = AppConst.STREAMING_PATH + "/" + target_.ToString();
		if (!Directory.Exists (absOutPath)) 
		{
			Directory.CreateDirectory (absOutPath);
			AssetDatabase.Refresh ();
		}
		string relativeOutPath = absOutPath.Substring(AppConst.PROJECT_PATH_LEN + 1);

		BuildAssetBundleOptions options = BuildAssetBundleOptions.DeterministicAssetBundle | BuildAssetBundleOptions.UncompressedAssetBundle;
		BuildPipeline.BuildAssetBundles(relativeOutPath, s_abMaps.ToArray(), options, target_);
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
			string[] fileList = Directory.GetFiles(s_luaSrcDirs[i], "*.lua", SearchOption.AllDirectories);
			for (int k = 0; k < fileList.Length; ++k) 
			{
				// "/xxx.lua" or "/*/xxx.lua"
				string subName = fileList[k].Substring(s_luaSrcDirs[i].Length);
				string dstName = tempLuaDir + subName + ".bytes";
				Directory.CreateDirectory(Path.GetDirectoryName(dstName));
				EncodeLuaFile(fileList[k], dstName);
                UpdateProgress(k++, fileList.Length, "Encoding lua files");
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
		//string resPath = "";//AppDataPath + "/" + AppConst.AssetDir + "/";
		//if (!Directory.Exists(resPath)) Directory.CreateDirectory(resPath);
        string resPath = Application.dataPath + "/Delete/Prefabs/Login";
        string relativePath = resPath.Substring(AppConst.PROJECT_PATH_LEN+1);

        AddBuildMap("role_login" + AppConst.AB_EXT_NAME, relativePath, "*.prefab");
		/*
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


    //private static string s_uploadLocalDir;
    //private static string s_uploadRemoteDir;

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

    private static void UploadResource (BuildTarget target_)
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (target_ == BuildTarget.iOS || target_ == BuildTarget.StandaloneOSXIntel)
            {
                Debug.LogError(" upload ios/osx files from windows system is forbid");
                return;
            }
        }
        if (Application.platform == RuntimePlatform.OSXEditor)
        {
            if (target_ == BuildTarget.Android || target_ == BuildTarget.StandaloneWindows)
            {
                Debug.LogError(" upload win/android files from oxs system is forbid");
                return;
            }
        }

        string localDir = AppConst.STREAMING_PATH + "/" + target_.ToString();
        Debug.Log("upload file from dir:" + localDir);

        string[] fileList = Directory.GetFiles(localDir, "*", SearchOption.AllDirectories);
       // for (int i = 0; i < fileList.Length; ++i)
        {
            //UpdateProgress(i+1, fileList.Length, "Uploading files to web server");

            string fileName = fileList[0].Replace("\\", "/");
            string subName = fileName.Substring(localDir.Length);
            if (subName.StartsWith("/")) subName = subName.Substring(1);           

            string currDir = Directory.GetCurrentDirectory();
            string exeDir = string.Empty;

            ProcessStartInfo processInfo = new ProcessStartInfo();  
            processInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processInfo.ErrorDialog = true;

            if (Application.platform == RuntimePlatform.WindowsEditor) 
            {
                processInfo.FileName = "";
               // processInfo.Arguments = "-b " + srcFile_ + " " + outFile_;
                processInfo.UseShellExecute = true;
                exeDir = AppConst.PROJECT_PATH + "/LuaEncoder/luajit/";
            }
            else if (Application.platform == RuntimePlatform.OSXEditor) 
            {
                processInfo.FileName = "scp";
                processInfo.Arguments = "-r " + localDir + " root@" + AppConst.RES_SERVER_IP + ":" + AppConst.RES_SERVER_PATH;
                processInfo.UseShellExecute = false;
                //exeDir = AppConst.PROJECT_PATH + "/LuaEncoder/luavm/";
            }

            Debug.Log(processInfo.FileName + " " + processInfo.Arguments);
            //Directory.SetCurrentDirectory(exeDir);
            Process.Start(processInfo).WaitForExit();
            //Directory.SetCurrentDirectory(currDir);
            /*
            string remoteFileURL = AppConst.UPLOAD_ASSET_URL + "/" + fileName.Substring(fileName.LastIndexOf("/"));
            Debug.Log("upload file:" + fileName + " to " + remoteFileURL);

            FileStream fs = File.OpenRead(fileName);
            byte[] fileBytes = new byte[fs.Length];
            fs.Read(fileBytes, 0, fileBytes.Length);
            fs.Close();

            FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(remoteFileURL);
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Credentials = new NetworkCredential("tfx", "sunrise");
            req.ContentLength = fileBytes.Length;
            req.KeepAlive = true;
            req.UseBinary = true;
            req.Timeout = 50*1000;

            Stream ftpStream = req.GetRequestStream();
            ftpStream.Write(fileBytes, 0, fileBytes.Length);
            ftpStream.Dispose();
            ftpStream = null;
            */
        }
    }
}
