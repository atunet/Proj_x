using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CharacterController))]
public class ToonControll : MonoBehaviour {

    private Animator m_animator;
    private CharacterController m_character;
    public float m_moveSpeed = 1f;
    private bool m_moving = false;

    private int m_cornerIndex = 0;
    private UnityEngine.AI.NavMeshPath m_navPath;

    private Quaternion m_destRotation = Quaternion.identity;
    public float m_rotateSpeed = 100f;

    private float m_lastTime = 0f;
    public Transform m_target;

	// Use this for initialization
	void Start () {
        m_animator = GetComponent<Animator>();
        m_character = GetComponent<CharacterController>();

        m_navPath = new UnityEngine.AI.NavMeshPath();

	}
	
	// Update is called once per frame
	void Update () {
		
        if (Time.time - m_lastTime > 3f)
        {            
            int rand = Random.Range(0, 3);  
            if (0 == rand)
            {
                m_animator.SetBool("Attack", false);
                m_animator.SetFloat("Speed", 0.9f);
                transform.LookAt(m_target.position);

            }
            else if (1 == rand)
            {
                m_animator.SetBool("Attack", true);
                m_animator.SetFloat("Speed", 0f);
            }
            else if (2 == rand)
            {
                m_animator.SetBool("Attack", false);
                m_animator.SetFloat("Speed", 0.3f);
                transform.LookAt(m_target.position);

            }
            m_lastTime = Time.time;
        }

        AnimatorStateInfo stateInfo = m_animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Walk") || stateInfo.IsName("Charge"))
        {
            transform.Translate(Vector3.forward*Time.deltaTime, Space.Self);
        }
	}
}
