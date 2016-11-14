using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (NavMeshAgent))]
public class NavAgentController : MonoBehaviour 
{
    private NavMeshAgent m_agent;
    private Animator m_animator;
    private ThirdController m_3rd;
    private ThirdPersonCharacter m_3rdperson;

	// Use this for initialization
	void Start () 
    {	
        m_agent = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
        m_3rd = GetComponent<ThirdController>();
        m_3rdperson = GetComponent<ThirdPersonCharacter>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                m_agent.SetDestination(hit.point);
            }
        }
        if (m_agent.remainingDistance < m_agent.stoppingDistance)
        {
            m_agent.enabled = false;
        }
        else
        {
            Debug.Log("remaining distance:" + m_agent.remainingDistance + "," + m_agent.stoppingDistance);
        }
	}
}
