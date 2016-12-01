using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour 
{
    private float m_lastAttackTime = 0f;
    private float m_lastSkill1Time = 0f;
    private float m_lastSkill2Time = 0f;
    private float m_lastSkill3Time = 0f;

    public void OnStart()
    {
        m_lastAttackTime = Time.time - 3f;
        m_lastSkill1Time = m_lastAttackTime;
        m_lastSkill2Time = m_lastAttackTime;
        m_lastSkill3Time = m_lastAttackTime;
    }

    public void OnAttackClick()
    {
        Debug.Log("OnAttackClick called");
        if (Time.time - m_lastAttackTime > 3)
        {
            m_lastAttackTime = Time.time;
        }
    }

    public void OnSkill1Click()
    {
        Debug.Log("OnSkill1Click called");
        if (Time.time - m_lastSkill1Time > 3)
        {
            m_lastSkill1Time = Time.time;
        }
    }

    public void OnSkill2Click()
    {
        Debug.Log("OnSkill2Click called");
        if (Time.time - m_lastSkill2Time > 3)
        {
            m_lastSkill2Time = Time.time;
        }
    }

    public void OnSkill3Click()
    {        
        Debug.Log("OnSkill3Click called");
        if (Time.time - m_lastSkill3Time > 3)
        {           
            m_lastSkill3Time = Time.time;            
        }
    }

    public void OnPauseClick()
    {
        Debug.Log("OnPauseClick called");
    }

    public void OnExitClick()
    {
        Debug.Log("OnExitClick called");
    }
}
