using UnityEngine;
using System.Collections;

public class ChapterController : MonoBehaviour 
{
    public static GameObject s_playUIPrefab = null;
    public static GameObject s_playPrefab = null;

    void Start()
    {
        // TODO init ... chapter data ...
        //GlobalRef.s_gr.PlayMusic(EBGMusic.BG_MUSIC_MAIN);
    }

    public void OnStartClick()
    {
        InitPlayUI();

      //  InitPlayWindow();

        Destroy(gameObject);
    }

    public static void InitPlayUI ()
    {
        if (null == s_playUIPrefab)
        {
            s_playUIPrefab = Resources.Load("Prefabs/PlayUI") as GameObject;
        }

        GameObject playUI = Instantiate(s_playUIPrefab);
        playUI.transform.SetParent(GlobalRef.s_gr.m_uiCanvas);
        playUI.name = "PlayUI";

        RectTransform rectTrans = playUI.GetComponent<RectTransform>();
        if (rectTrans)
        {
            rectTrans.anchorMin = new Vector2(0.0f, 0.0f);
            rectTrans.anchorMax = new Vector2(1.0f, 1.0f);
            rectTrans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            rectTrans.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        }
        
        GlobalRef.s_gr.PlayUIRoot = playUI;
    }
    /*
    public static void InitPlayWindow()
    {
        if (null == s_playPrefab)
        {
            s_playPrefab = Resources.Load("Prefabs/PlayRoot") as GameObject;
        }

        GameObject PlayRoot = Instantiate(s_playPrefab);
        PlayRoot.transform.SetParent(GlobalRef.s_gr.m_playCanvas);
        PlayRoot.name = "PlayRoot";

        RectTransform rectTrans = PlayRoot.GetComponent<RectTransform>();
        if (rectTrans)
        {
            rectTrans.anchorMin = new Vector2(0.0f, 0.0f);
            rectTrans.anchorMax = new Vector2(1.0f, 1.0f);
            rectTrans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            rectTrans.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        }

        GlobalRef.s_gr.PlayRoot = PlayRoot;
    }*/
}
