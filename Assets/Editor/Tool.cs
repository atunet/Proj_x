using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;

public class Tool : MonoBehaviour 
{	   
	static string s_inputDir = Application.dataPath + "/Config/";
	static string s_outputDir = Application.dataPath + "/Scripts/LuaLogic/config/";
	
	[MenuItem("Tool/Csv To Lua")]
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
}
