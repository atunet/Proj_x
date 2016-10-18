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
            float v = xInputManager.GetVerticalValue();
            m_animator.SetFloat("Speed", v);

            float h = xInputManager.GetHorizontalValue();
            m_animator.SetFloat("Direction", h);
        }
	}

    void OnAnimatorMove()
    {
        AnimatorStateInfo currentState = m_animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsName("Base Layer.Run"))
        {
            float v = m_animator.GetFloat("Speed");

            Vector3 newPos = transform.position;
            newPos.z += v * Time.deltaTime;

            float h = m_animator.GetFloat("Direction");
            newPos.x += h * Time.deltaTime;

            transform.position = newPos;
        }
    }
}
