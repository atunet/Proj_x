using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GoblinController : MonoBehaviour {

    private Animator m_animator;

	// Use this for initialization
	void Start () {
	
        m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
        if (m_animator)
        {         
            float h = xInputManager.GetHorizontalValue();
            float hRaw = xInputManager.GetHorizontalValueRaw();

            float v = xInputManager.GetVerticalValue();
            float vRaw = xInputManager.GetVerticalValueRaw();

            if (Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0)
            {
                Debug.Log("axis,h:" + h + ",hraw:" + hRaw + ",v:" + v + ",vRaw:" + vRaw);
            }
            m_animator.SetInteger("moving", (int)hRaw);
        }
	}
}
