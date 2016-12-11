using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GoblinController : MonoBehaviour 
{
    private Animator m_animator;
    private CharacterController m_cc;

    private UnityEngine.AI.NavMeshAgent m_navAgent;
    bool m_pathFinding = false;

    private Quaternion m_targetRotation = Quaternion.identity;
    public float m_moveSpeed = 8f;

	void Start () 
    {	        
        m_animator = GetComponent<Animator>();
        m_cc = GetComponent<CharacterController>();
        m_navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	void Update () 
    {	
        if (!m_animator) return;

        float v = xInputManager.GetVerticalValueRaw();
        float h = xInputManager.GetHorizontalValueRaw();

        if (v != 0f || h != 0f)
        {
            m_navAgent.Stop();
            m_pathFinding = false;

            m_animator.SetFloat("Speed", 1f);
            m_targetRotation = xInputManager.GetWorldRotation(v, h);
            Debug.Log("rotation degree:" + xInputManager.GetWorldRotation(v, h).eulerAngles.ToString());
        }

        if (m_pathFinding)
        {
            m_animator.SetFloat("Speed", 1f);
            if (m_navAgent.remainingDistance == 0f)
            {
                m_pathFinding = false;
            }
        }
        else
        {
            /*float v = xInputManager.GetVerticalValueRaw();
            float h = xInputManager.GetHorizontalValueRaw();
                  
            if (v != 0f || h != 0f)
            {            
                m_animator.SetFloat("Speed", 1f);
                m_targetRotation = xInputManager.GetWorldRotation();
                Debug.Log("rotation degree:" + xInputManager.GetWorldRotation().eulerAngles.ToString());
            }
            else */
            {
                m_animator.SetFloat("Speed", 0f);
            }
        }

        AnimatorStateInfo currentState = m_animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsName("Base Layer.Run"))
        {
            if (Quaternion.Angle(transform.rotation, m_targetRotation) > 1f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, m_targetRotation, 10f * Time.deltaTime);
                //Debug.Log("after rotation lerp:" + transform.rotation.ToString() + ",target:" + m_targetRotation.ToString());
            }

            if (!m_pathFinding)
            {
                m_cc.SimpleMove(transform.forward * m_moveSpeed);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 destPos = hit.point;
                m_navAgent.SetDestination(destPos);
                m_pathFinding = true;
            }
        }
	}

  
    void OnAnimatorMove()
    {
        AnimatorStateInfo currentState = m_animator.GetCurrentAnimatorStateInfo(0);
        if (currentState.IsName("Base Layer.Run"))
        {
        }
    }

    public void OnAttack()
    {
        //Debug.Log("DoAttack");
        /*
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; ++i)
            {
                GameObject theGo = colliders[i].gameObject;
                if (theGo.layer == 8)
                    continue;
                
                Animator theAnimtor = theGo.GetComponent<Animator>();
                if (theAnimtor)
                {
                    AnimatorStateInfo theState = theAnimtor.GetCurrentAnimatorStateInfo(0);
                    if (theState.IsName("Idle") || theState.IsName("Run"))
                    {
                        theAnimtor.SetTrigger("DamageDown");
                        Debug.Log("object attacked:" + theGo.name);
                    }                
                }
            }
        }
        */
    }
}
