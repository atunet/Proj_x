using UnityEngine;
using System.Collections;

[RequireComponent(typeof (NavMeshAgent))]
public class NavAgentController : MonoBehaviour 
{
    private NavMeshAgent m_agent;
    private Animator m_animator;

	// Use this for initialization
	void Start () 
    {	
        m_agent = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
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
                m_animator.SetFloat("Speed", 1f);
            }
        }
	}
}
