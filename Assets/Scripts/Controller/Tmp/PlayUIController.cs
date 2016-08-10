using UnityEngine;
using System.Collections;

public class PlayUIController : MonoBehaviour 
{      
    public GameObject m_resultRoot = null;

    public void Start()
    {
        // TODO ... init PlayUI ...

        m_resultRoot = this.transform.FindChild("ResultRoot").gameObject;

        RectTransform rectTrans = this.gameObject.GetComponent<RectTransform>();
        if (rectTrans)
        {
            rectTrans.anchorMin = new Vector2(0.0f, 0.0f);
            rectTrans.anchorMax = new Vector2(1.0f, 1.0f);
            rectTrans.localScale = Vector3.one; 
            rectTrans.localPosition = Vector3.zero;
            rectTrans.offsetMin = new Vector2(0f, 0f);
            rectTrans.offsetMax = new Vector2(0f, 0f);
        }
    }
    /*
    public IEnumerator showResult()
    {
        yield return new WaitForSeconds(2f);
        m_resultRoot.SetActive(true);
    }

    public void OnReturnClick()
    {
        GlobalRef.s_gr.m_playCamera.transform.localPosition = new Vector3(7000f, 0f, 500f);

        MyFollow follow = GlobalRef.s_gr.m_playCamera.GetComponent<MyFollow>();
        Destroy(follow);

        Destroy(GlobalRef.s_gr.PlayRoot);
        Destroy(GlobalRef.s_gr.PlayUIRoot);

        GlobalRef.s_gr.PlayRoot = null;
        GlobalRef.s_gr.PlayUIRoot = null;

        LoginController.InitChapterUI();
    }
    
    public void OnAgainClick()
    {
        GlobalRef.s_gr.m_playCamera.transform.localPosition = new Vector3(7000f, 0f, 500f);

        MyFollow follow = GlobalRef.s_gr.m_playCamera.GetComponent<MyFollow>();
        Destroy(follow);
        
        Destroy(GlobalRef.s_gr.PlayRoot);
        Destroy(GlobalRef.s_gr.PlayUIRoot);
        
        GlobalRef.s_gr.PlayRoot = null;
        GlobalRef.s_gr.PlayUIRoot = null;
        
        ChapterController.InitPlayUI();
        ChapterController.InitPlayWindow();
    }
    */
}
