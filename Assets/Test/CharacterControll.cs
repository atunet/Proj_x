using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CharacterController))]
public class CharacterControll : MonoBehaviour 
{
    private Animator m_animator;
    private CharacterController m_character;
    public float m_moveSpeed = 1f;
    private bool m_moving = false;

    private int m_cornerIndex = 0;
    private UnityEngine.AI.NavMeshPath m_navPath;

    private Quaternion m_destRotation = Quaternion.identity;
    public float m_rotateSpeed = 100f;

    private Vector2 m_touchStartPos = Vector2.zero;

    void Start () 
    {
        m_animator = GetComponent<Animator>();
        m_character = GetComponent<CharacterController>();
        m_navPath = new UnityEngine.AI.NavMeshPath();
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 destPoint = hit.point;
                if (UnityEngine.AI.NavMesh.CalculatePath(transform.position, destPoint, -1, m_navPath))
                {
                    m_moving = true;
                    m_cornerIndex = -1;
                    Debug.Log("auto pathing begin,dest x:" + destPoint.x + ",z:" + destPoint.z);
                }
            }
        }

        if (m_navPath.corners.Length > 0)
        {
            bool changeCorner = false;
            if (m_cornerIndex < 0)
            {
                m_cornerIndex = 0;
                changeCorner = true;
            }

            if (0.5f > Vector3.Distance(transform.position, m_navPath.corners[m_cornerIndex]))
            {
                m_cornerIndex++;
                if (m_navPath.corners.Length <= m_cornerIndex)
                {
                    m_moving = false;
                    m_navPath.ClearCorners();
                    Debug.Log("auto pathing end,current pos,x:" + transform.position.x + ",z:" + transform.position.z);
                }
                else
                {
                    changeCorner = true;
                }
            }

            if (changeCorner)
            {
                m_destRotation = xInputManager.GetWorldRotation(
                    m_navPath.corners[m_cornerIndex].x - transform.position.x,
                    m_navPath.corners[m_cornerIndex].z - transform.position.z);

                Debug.Log("next nav corner:" + m_navPath.corners[m_cornerIndex].x + "," + m_navPath.corners[m_cornerIndex].z);
            }
        }
                  
        float h = xInputManager.GetHorizontalValue();
        float v = xInputManager.GetVerticalValue();
        if (h != 0f || v != 0f)
        {
            m_moving = true;
            m_destRotation = xInputManager.GetWorldRotation(h, v);          
        }
        else
        {
            if (m_navPath.corners.Length <= 0)
            {
                m_moving = false;
            }
        }

        if (m_moving)
        {
            m_character.SimpleMove(transform.forward * m_moveSpeed);
            m_animator.SetFloat("Forward", 1f);
        }
        else
        {
            m_animator.SetFloat("Forward", 0f);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, m_destRotation, m_rotateSpeed);
        /*
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                m_touchStartPos = t.position;
            }
            else if (t.phase == TouchPhase.Ended)
            {
                Vector2 deltaPos = t.position - m_touchStartPos;
                if (deltaPos.x > 0f)
                {
                    if (deltaPos.y > 0f && deltaPos.y > deltaPos.x)
                    {
                        Debug.Log("touch slide to up");
                    }
                    else if (deltaPos.y < 0f && Mathf.Abs(deltaPos.y) > deltaPos.x)
                    {
                        Debug.Log("touch slide bottom");
                    }
                    else
                    {
                        Debug.Log("touch slide right");
                    }
                }
                else if (deltaPos.x < 0f)
                {
                    if (deltaPos.y > 0f && deltaPos.y > Mathf.Abs(deltaPos.x))
                    {
                        Debug.Log("touch slide to up");
                    }
                    else if (deltaPos.y < 0f && Mathf.Abs(deltaPos.y) >  Mathf.Abs(deltaPos.x))
                    {
                        Debug.Log("touch slide bottom");
                    }
                    else
                    {
                        Debug.Log("touch slide left");
                    }
                }

                m_touchStartPos = Vector2.zero;
            }
        }
        */
    }


    void OnGUI()
    {
    }

}
