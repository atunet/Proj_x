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
        if (m_abMaps.TryGetValue(abName_, out ab)) return ab;

        AssetBundle depAB = null;
        string depABName = "sprite_logo";
        if (!m_abMaps.TryGetValue(depABName, out depAB))
        {
            depAB = AssetBundle.LoadFromFile(AppConst.PERSISTENT_PATH + "/" + depABName + AppConst.AB_EXT_NAME);
            m_abMaps.Add(depABName, depAB);

            if(null == depAB)
                Debug.Log("ABManager: load dep ab file failed:" + depABName + AppConst.AB_EXT_NAME);
        }

        ab = AssetBundle.LoadFromFile(AppConst.PERSISTENT_PATH + "/" + abName_ + AppConst.AB_EXT_NAME);
        if (null != ab)
        {           
            Debug.Log("ABManager: load ab file success:" + abName_ + AppConst.AB_EXT_NAME);
            m_abMaps.Add(abName_, ab);
        }
        else
            Debug.LogError("ABManager: load ab failed,file not existed:" + abName_ + AppConst.AB_EXT_NAME);

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
