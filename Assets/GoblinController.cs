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
            int val = (int)CrossPlatformInputManager.GetAxisRaw("Horizontal");
            int val2 = (int)CrossPlatformInputManager.GetAxisRaw("Vertical");
            Debug.Log("GoblinController:" + val + ',' + val2);

            m_animator.SetInteger("moving", 1);
        }
	}
}
