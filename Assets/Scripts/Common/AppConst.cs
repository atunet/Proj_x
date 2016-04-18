﻿using UnityEngine;
using UnityEditor;
using System.IO;

public static class AppConst
{
	public static string ASSETS_DIR_NAME = "/Assets";
	public static string PROJECT_PATH = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf(ASSETS_DIR_NAME));	// without last '/'
	public static int PROJECT_PATH_LEN = PROJECT_PATH.Length;	// without last '/'

	public static string PLATFORM = Application.platform.ToString();
	public static string COMMON_SUB_PATH = "RawResources";
	public static string MANIFEST_FILE_NAME = PLATFORM;

	public static string STREAMING_PATH = Application.streamingAssetsPath + "/" + PLATFORM;
	public static string STREAMING_RELATIVE_PATH = Application.streamingAssetsPath.Substring(PROJECT_PATH_LEN+1);
	public static string STREAMING_MANIFEST_FULL_NAME = STREAMING_PATH + "/" + MANIFEST_FILE_NAME;

    public static string PERSISTENT_SUB_PATH = Path.Combine(Application.persistentDataPath, COMMON_SUB_PATH);
	public static string PERSISTENT_PATH = Application.persistentDataPath + "/" + PLATFORM;
    public static string PERSISTENT_MANIFEST_FULL_NAME = Path.Combine(PERSISTENT_PATH, MANIFEST_FILE_NAME);

	public static string REMOTE_URL = "http://121.199.48.63/res/firework";
    public static string REMOTE_ASSET_URL = REMOTE_URL + "/" + PLATFORM;							// do not use Path.Combine()
	public static string REMOTE_MANIFEST_FULL_URL = REMOTE_ASSET_URL + "/" + MANIFEST_FILE_NAME;	// do not use Path.Combine()

    public static string RES_SERVER_IP = "121.199.48.63";
    public static string RES_SERVER_PATH = "/var/www/html/res/firwork";
    public static string UPLOAD_URL = "ftp://121.199.48.63/res/firework";
	public static string UPLOAD_ASSET_URL = UPLOAD_URL + "/" + PLATFORM;							// do not use Path.Combine()

	public static string LUA_TEMP_PATH = "Assets/StreamingAssets/Temp/Lua";
	public static string LUA_TOLUA_PATH = Application.dataPath + "/ToLua/Lua/protobuf";
	public static string LUA_LOGIC_PATH = Application.dataPath + "/Scripts/LuaScripts";
	public static string LUA_PROTO_PATH = Application.dataPath + "/Scripts/LuaScripts/Protos";
	
	public static string AB_EXT_NAME = ".unity3d";


	public static void PrintPath()
	{
		Debug.Log ("PROJ_PATH:" + PROJECT_PATH + ",len:" + PROJECT_PATH_LEN);

		Debug.Log("PLATFROM:" + PLATFORM);
		Debug.Log("COMMON_SUB_PATH:" + COMMON_SUB_PATH);
		Debug.Log("MANIFEST_FILE_NAME:" + MANIFEST_FILE_NAME);

		Debug.Log("STREAMING_ASSETS_PATH:" + STREAMING_PATH);
		Debug.Log("STREAMING_MANIFEST_FULL_NAME:" + STREAMING_MANIFEST_FULL_NAME);

		Debug.Log("PERSISTENT_SUB_PATH:" + PERSISTENT_SUB_PATH);
		Debug.Log("PERSISTENT_DATA_PATH:" + PERSISTENT_PATH);
		Debug.Log("PERSISTENT_MANIFEST_FULL_NAME:" + PERSISTENT_MANIFEST_FULL_NAME);

		Debug.Log("REMOTE_URL:" + REMOTE_URL);
		Debug.Log("REMOTE_ASSET_URL:" + REMOTE_ASSET_URL);
		Debug.Log("REMOTE_MANIFEST_FULL_URL:" + REMOTE_MANIFEST_FULL_URL);

		Debug.Log("UPLOAD_URL:" + UPLOAD_URL);
		Debug.Log("UPLOAD_ASSET_URL:" + UPLOAD_ASSET_URL);

		Debug.Log("TEMP_PATH:" + Application.temporaryCachePath);
	}	 
}
