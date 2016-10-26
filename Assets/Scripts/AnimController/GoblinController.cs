using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GoblinController : MonoBehaviour 
{
    private Animator m_animator;
    private CharacterController m_cc;

    private Quaternion m_targetRotation = Quaternion.identity;
    public float m_moveSpeed = 8f;

	void Start () 
    {	        
        m_animator = GetComponent<Animator>();
        m_cc = GetComponent<CharacterController>();
	}
	
	void Update () 
    {	
        if (!m_animator) return;

        float v = xInputManager.GetVerticalValueRaw();
        float h = xInputManager.GetHorizontalValueRaw();
                  
        if (v != 0f || h != 0f)
        {            
            m_animator.SetFloat("Speed", 1f);
            m_targetRotation = xInputManager.GetWorldRotation();
            Debug.Log("rotation degree:" + xInputManager.GetWorldRotation().eulerAngles.ToString());
        }
        else
        {
            m_animator.SetFloat("Speed", 0f);
        }

        AnimatorStateInfo currentState = m_animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsName("Base Layer.Run"))
        {
            if (Quaternion.Angle(transform.rotation, m_targetRotation) > 2f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, m_targetRotation, 10f * Time.deltaTime);
                //Debug.Log("after rotation lerp:" + transform.rotation.ToString() + ",target:" + m_targetRotation.ToString());
            }

            m_cc.SimpleMove(transform.forward * m_moveSpeed);
        }
	}

  
    void OnAnimatorMove()
    {
        AnimatorStateInfo currentState = m_animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsName("Base Layer.Run"))
        {
        }
    }
}
