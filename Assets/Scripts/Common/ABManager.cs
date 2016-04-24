using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ABManager
{
    public static ABManager Instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = new ABManager();
            }
            return s_instance;
        }
    }
    private static ABManager s_instance = null;

    private Dictionary<string, AssetBundle> m_abMaps = null;
    private ABManager() { m_abMaps = new Dictionary<string, AssetBundle>(); }

    public AssetBundle get(string abName_)
    {
        AssetBundle ab = null;
        if (m_abMaps.TryGetValue(abName_, out ab))
        {
            return ab;
        }

        ab = AssetBundle.LoadFromFile(AppConst.PERSISTENT_PATH + "/" + abName_ + AppConst.AB_EXT_NAME);
        if (null == ab) 
        {
            Debug.LogError("load ab failed,file not existed:" + abName_ + AppConst.AB_EXT_NAME);
        }
        else
            Debug.Log("load ab file success:" + abName_ + AppConst.AB_EXT_NAME);

        m_abMaps.Add(abName_, ab);
        return ab;
    }

    public void UnloadAB(string abName_)
    {
        AssetBundle ab = null;
        if (m_abMaps.TryGetValue(abName_, out ab))
        {
            Resources.UnloadAsset(ab);
            Resources.UnloadUnusedAssets();

            m_abMaps.Remove(abName_);
        }
    }
}
