using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (NavMeshAgent))]
[RequireComponent(typeof (CharacterController))]
public class CharacterControll : MonoBehaviour 
{
    private Animator m_animator;
    private CharacterController m_character;

    private Quaternion m_destRotation = Quaternion.identity;
    public float m_rotateSpeed = 20f;
    public float m_moveSpeed = 2f;

    private bool m_pathFinding = false;
    private int m_cornerIndex = 0;
    private NavMeshPath m_navPath;

    void Start () 
    {
        m_animator = GetComponent<Animator>();
        m_character = GetComponent<CharacterController>();
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 destPoint = hit.point;
                if (NavMesh.CalculatePath(transform.position, destPoint, -1, m_navPath))
                {
                    m_pathFinding = true;
                    m_cornerIndex = 0;
                    m_destRotation = xInputManager.GetWorldRotation(m_navPath.corners[m_cornerIndex].x, m_navPath.corners[m_cornerIndex].z);
                }
            }
        }

        if (m_navPath.corners.Length > 0)
        {
            if (0.1f > Vector3.Distance(transform.position, m_navPath.corners[m_cornerIndex]))
            {
                m_cornerIndex++;
                if (m_navPath.corners.Length <= m_cornerIndex)
                {
                    m_pathFinding = false;
                    m_navPath.ClearCorners();
                }
                else
                {
                    m_destRotation = xInputManager.GetWorldRotation(m_navPath.corners[m_cornerIndex].x, m_navPath.corners[m_cornerIndex].z);
                }
            }
        }
                  
        float h = xInputManager.GetHorizontalValue();
        float v = xInputManager.GetVerticalValue();

        if (h != 0f || v != 0f)
        {
            m_pathFinding = true;
            m_destRotation = xInputManager.GetWorldRotation(h, v);          
        }
        else
        {
            if (m_pathFinding)
            {
                m_destRotation = m_navPath;
                m_character.SimpleMove(transform.forward * m_moveSpeed);
                m_animator.SetFloat("Forward", 1f);
            }
            else
            {
                m_animator.SetFloat("Forward", 0f);
            }
        }

        if (m_pathFinding)
        {
            m_character.SimpleMove(transform.forward * m_moveSpeed);
            m_animator.SetFloat("Forward", 1f);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, m_destRotation, m_rotateSpeed);
    }



}
