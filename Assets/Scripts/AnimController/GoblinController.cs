using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GoblinController : MonoBehaviour {

    private Animator m_animator;
    private Transform m_trans;
    private Vector3 destionPos;
    // private bool m_turnAround = false;
	// Use this for initialization
    private Quaternion m_targetRotation = Quaternion.identity;

	void Start () {
	
        m_animator = GetComponent<Animator>();
        m_trans = GetComponent<Transform>();
        destionPos = m_trans.position + Vector3.one * 100;
        Debug.Log("start:" + m_trans.position.ToString() + " -> " + destionPos.ToString());


        Vector3 from = Vector3.one;
        Vector3 to = new Vector3(100f, 200f, 300f);
        Quaternion q = Quaternion.identity;
        q.SetFromToRotation(from, to);
        Debug.Log("SetFromToRotation:" + q.eulerAngles.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
        if (m_animator)
        {    
            float v = xInputManager.GetVerticalValue();
            float h = xInputManager.GetHorizontalValue();
                      
            if (v != 0f || h != 0f)
            {
                float speed = v * v;
                if (h != 0f) speed = h * h;
                m_animator.SetFloat("Speed", speed);
                //m_animator.SetFloat("Direction", h);
                m_targetRotation = xInputManager.GetWorldRotation();
                Debug.Log("rotation degree:" + xInputManager.GetWorldRotation().eulerAngles.ToString());
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, m_targetRotation, 10f);
           /* if (v < 0f)
            {              
                if(!m_turnAround)
                {
                    m_dstRotation = m_trans.rotation;
                    m_trans.Rotate(Vector3.up, 180.0f);
                    m_turnAround = true;
                }
            }
            else
            {
                m_turnAround = false;
            }
*/
//            if (Input.GetKeyDown(KeyCode.S))
//            {
//                Vector3 deltaRotation = new Vector3(0f, 180f, 0f);
//                Vector3 targetRotation = transform.localRotation.eulerAngles + deltaRotation;
//                target = Quaternion.Euler(targetRotation);
//            }
//
//            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, target, 10f);
            //transform.localRotation = Quaternion.LookRotation(target.eulerAngles);
        }
        //Debug.Log(m_trans.position.ToString() + "....magnitude:" + (destionPos-m_trans.position).magnitude);
        //Vector3 tmp = Vector3.MoveTowards(m_trans.position, destionPos, 10f);
        //Debug.Log(tmp.ToString() + "....magnitude:" + (tmp-m_trans.position).magnitude);
        //m_trans.position = tmp;

        //m_trans.position = m_trans.position.normalized * (m_trans.position.magnitude + 10f);
        //Debug.Log(m_trans.position.ToString() + "....");

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

            //transform.LookAt(new Vector3(transform.position.x + h, transform.position.y, transform.position.z + v));  
            //移动玩家的位置（按朝向位置移动）  
            transform.Translate(Vector3.forward * Time.deltaTime * 17.5F);  
        }
    }
}
