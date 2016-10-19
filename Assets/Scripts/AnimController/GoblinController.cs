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
           // float v = m_animator.GetFloat("Speed");

            //transform.Translate(Vector3.forward * 2 * v * Time.deltaTime);

            //Vector3 newPos = transform.position;
            //newPos.z += 2 * v * Time.deltaTime;

            //float h = m_animator.GetFloat("Direction");
            //newPos.x += h * Time.deltaTime;

            //transform.position = newPos;
            float v = xInputManager.GetVerticalValue();
            float h = xInputManager.GetHorizontalValue();

            transform.LookAt(new Vector3(transform.position.x + h, transform.position.y, transform.position.z + v));  
            //移动玩家的位置（按朝向位置移动）  
            transform.Translate(Vector3.forward * Time.deltaTime * 7.5F);  
        }
    }
}
