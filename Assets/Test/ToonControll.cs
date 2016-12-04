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

	// Use this for initialization
	void Start () {
        m_animator = GetComponent<Animator>();
        m_character = GetComponent<CharacterController>();

        m_navPath = new UnityEngine.AI.NavMeshPath();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
