using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GoblinController : MonoBehaviour 
{
    private Transform m_trans;
    private Animator m_animator;
    private Rigidbody m_rigidBody;
    private float m_moveSpeed = 1000f;
    private bool m_moving = false;
    private Quaternion m_targetRotation = Quaternion.identity;

	void Start () 
    {	
        m_trans = GetComponent<Transform>();
        m_animator = GetComponent<Animator>();
        m_rigidBody = GetComponent<Rigidbody>();
	}
	
	void Update () 
    {	
        if (!m_animator) return;

        float v = xInputManager.GetVerticalValueRaw();
        float h = xInputManager.GetHorizontalValueRaw();
                  
        if (v != 0f || h != 0f)
        {
            float speed = v * v;
            if (h != 0f)
                speed = h * h;
            m_animator.SetFloat("Speed", speed);
            m_targetRotation = xInputManager.GetWorldRotation();
            Debug.Log("rotation degree:" + xInputManager.GetWorldRotation().eulerAngles.ToString());
        }
        else
        {
            m_animator.SetFloat("Speed", 0f);
        }
        if (Quaternion.Angle(transform.rotation, m_targetRotation) > 1f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, m_targetRotation, 10f * Time.deltaTime);
            Debug.Log("after rotation lerp:" + transform.rotation.ToString() + ",target:" + m_targetRotation.ToString());
        }

        AnimatorStateInfo currentState = m_animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsName("Base Layer.Run"))
        {
            //transform.Translate(0f, 0f, m_moveSpeed*Time.deltaTime);
            m_rigidBody.velocity = transform.forward * m_moveSpeed * Time.deltaTime;
            Debug.Log("Now is runing");
        }
        else
        {
            m_rigidBody.velocity = Vector3.zero;
        }
	}

  
    void OnAnimatorMove()
    {/*
        AnimatorStateInfo currentState = m_animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsName("Base Layer.Run"))
        {
            //transform.Translate(0f, 0f, m_moveSpeed*Time.deltaTime);
            m_rigidBody.velocity = transform.forward * m_moveSpeed * Time.deltaTime;
            Debug.Log("Now is runing");
        }
        else
        {
            m_rigidBody.velocity = Vector3.zero;
        }
        */
    }
}
