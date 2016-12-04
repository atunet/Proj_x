using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CharacterController))]
public class ZombieControll : MonoBehaviour 
{

    public enum EState
    {
        IDLE,
        WALK,
        ATTACK,
        DANGER,
    }
    private EState m_state = EState.IDLE;

    private Animator m_animator;
    private CharacterController m_character;
    public float m_moveSpeed = 1f;
    private bool m_moving = false;

    private int m_cornerIndex = 0;
    private UnityEngine.AI.NavMeshPath m_navPath;

    private Quaternion m_destRotation = Quaternion.identity;
    public float m_rotateSpeed = 100f;

    public Transform m_target;

	// Use this for initialization
	void Start () {
        m_animator = GetComponent<Animator>();
        m_character = GetComponent<CharacterController>();

        m_navPath = new UnityEngine.AI.NavMeshPath();

	}
	
	// Update is called once per frame
	void Update () 
    {
        float distance = Vector3.Distance(transform.position, m_target.position);

        if (distance > 15f)
        {
            m_state = EState.IDLE;
        }
        else
        {
            Vector3 temp = new Vector3(-1, -1, -1);
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                Quaternion.LookRotation(m_target.position-transform.position), 5*Time.deltaTime);

            if (distance > 3f)
            {
                m_state = EState.WALK;
                transform.position += transform.forward * 5 * Time.deltaTime;
            }
            else
            {
                m_state = EState.ATTACK;
            }
        }

        MonsterControll();
	}

    private void MonsterControll()
    {
        switch (m_state)
        {
            case EState.IDLE:
                {
                    m_animator.SetFloat("Speed", 0f);
                    m_animator.SetBool("Attack", false);
                }
                break;
            case EState.WALK:
                {
                    m_animator.SetFloat("Speed", 1f);
                    m_animator.SetBool("Attack", false);
                }
                break;
            case EState.ATTACK:
                {
                    m_animator.SetBool("Attack", true);
                    m_animator.SetFloat("Speed", 0f);
                }
                break;
            case EState.DANGER:
                {
                    m_animator.SetBool("Attack", true);
                    m_animator.SetFloat("Speed", 0f);
                }
                break;
        }
    }
}
