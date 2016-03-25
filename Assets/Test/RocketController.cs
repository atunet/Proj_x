using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class RocketController : MonoBehaviour 
{
    private static float s_g = 9.81f;

    private float m_startTime;
    private Rigidbody2D m_rigidbody2D;


    private bool upPressed = false;
    public bool UpPressed
    {
        get { return upPressed; }
        set { upPressed = value; }
    }

    private bool downPressed = false;
    public bool DownPressed
    {
        get { return downPressed; }
        set { downPressed = value; }
    }

    private bool leftPressed = false;
    public bool LeftPressed
    {
        get { return leftPressed; }
        set { leftPressed = value; }
    }

    private bool rightPressed = false;
    public bool RightPressed
    {
        get { return rightPressed; }
        set { rightPressed = value; }
    }


    public float maxVelocity = 500;
    public float minVelocity = 200f;
    public bool speedy = false;

	


    private float m_normalPower = 0f;
    public float m_boostingPower = 0f;

    void Start()
    {
        m_startTime = Time.time;
        m_rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

        m_normalPower = m_rigidbody2D.mass * s_g;
    }

	void FixedUpdate ()
	{
        if (EFlyState.FLY_FLYING != PlayController.s_playController.State)
        {
            return;
        }

        if (upPressed)
        {
            m_rigidbody2D.AddForce(new Vector2(0f, m_normalPower+m_boostingPower));

        } else if (downPressed)
        {
            m_rigidbody2D.AddForce(new Vector2(0f, 0f));

        } else if (rightPressed)
        {

        } else if (leftPressed)
        {
        }

        /*if (Time.time - m_startTime > 20f)
        {
            m_rigidbody2D.gravityScale = 4f;
            return;
        }

        if (speedy)
        {
            if(m_rigidbody2D.velocity.y < maxVelocity)
            {
                m_rigidbody2D.gravityScale = 1f;
                m_rigidbody2D.AddForce(Vector2.up * 2000f);
            }
            else m_rigidbody2D.gravityScale = 0f;

        } else
        {
            if(m_rigidbody2D.velocity.y > minVelocity)
            {
                m_rigidbody2D.gravityScale = 1f;
                m_rigidbody2D.AddForce(Vector2.up * -1000f);
            }
            else 
            {
                m_rigidbody2D.gravityScale = 1f;
                m_rigidbody2D.AddForce(Vector2.up * 1500f);
            }
        }
        */
        //Debug.Log("velocity:" + m_rigidbody2D.velocity);
	}


	void OnCollisionEnter2D(Collision2D collision_)
	{
        if (collision_.gameObject.name == "Terrain")
        { 
            if(PlayController.s_playController.State == EFlyState.FLY_FLYING)
            {
                PlayController.s_playController.State = EFlyState.FLY_OVER;

                PlayUIController uiController = GlobalRef.s_gr.PlayUIRoot.GetComponent<PlayUIController>();
                uiController.StartCoroutine("showResult");
                //uiController.m_resultRoot.SetActive(true);
            }
        }
	}
}
