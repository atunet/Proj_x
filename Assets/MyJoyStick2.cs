using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MyJoyStick2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler 
{
    enum State
    {
        IDLE,
        MOVING,
    }
    private State m_state;

    private Vector2 m_rootPostion;
    private float m_rootWidth;
    private float m_rootHeight;

    //private Vector2 m_rootSize;

    private RectTransform m_thumbRectTrans;
    private Vector2 m_thumbOriginPostion;

    private GameObject m_character;

	// Use this for initialization
	void Start () 
    {
        m_state = State.IDLE;

        RectTransform rootRectTrans = GetComponent<RectTransform>();
        m_rootPostion = rootRectTrans.anchoredPosition;
        m_rootWidth = rootRectTrans.sizeDelta.x / 2;
        m_rootHeight = rootRectTrans.sizeDelta.y / 2;

        m_thumbRectTrans = rootRectTrans.FindChild("thumb") as RectTransform;
        m_thumbOriginPostion = m_thumbRectTrans.anchoredPosition;

        Debug.Log("root x:" + m_rootPostion.x + ",y:" + m_rootPostion.y + ",width:" + m_rootWidth + ",height:" + m_rootHeight);
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (m_state == State.IDLE)
        {
            if (m_thumbRectTrans.anchoredPosition != m_thumbOriginPostion)
            {
                
            }
        }
        else if (m_state == State.MOVING)
        {
        }
	}

    public void OnPointerDown(PointerEventData data)
    {
        m_state = State.MOVING;

        float deltaX = data.position.x - m_rootPostion.x;
        float deltaY = data.position.y - m_rootPostion.y;
        if (Mathf.Pow(deltaX, 2) + Mathf.Pow(deltaY, 2) > Mathf.Pow(m_rootWidth, 2))
        {
            if (Mathf.Abs(deltaX) > m_rootWidth)
            {
                if (deltaX > 0)
                {
                    deltaX = m_rootWidth / Mathf.Sqrt(Mathf.Pow(Mathf.Abs(deltaY/deltaX), 2) + 1.0f); 
                }
                else
                    deltaX = -(m_rootWidth / Mathf.Sqrt(Mathf.Pow(Mathf.Abs(deltaY/deltaX), 2) + 1.0f));
            }

            if (Mathf.Abs(deltaY) > m_rootWidth)
            {
                if (deltaY > 0)
                {
                    deltaY = m_rootWidth / Mathf.Sqrt(Mathf.Pow(Mathf.Abs(deltaX/deltaY), 2) + 1.0f); 
                }
                else
                    deltaY = -(m_rootWidth / Mathf.Sqrt(Mathf.Pow(Mathf.Abs(deltaX/deltaY), 2) + 1.0f));
            }
        }
        m_thumbRectTrans.anchoredPosition = new Vector2(deltaX, deltaY);

        Debug.Log("OnPointerDown position," + data.position.x + "," + data.position.y);
    }

    public void OnPointerUp(PointerEventData data)
    {
        m_state = State.IDLE;
        m_thumbRectTrans.anchoredPosition = m_thumbOriginPostion;

        Debug.Log("OnPointerUp was called");
    }

    public void OnDrag(PointerEventData data)
    {
        float deltaX = data.position.x - m_rootPostion.x;
        float deltaY = data.position.y - m_rootPostion.y;
        if (Mathf.Pow(deltaX, 2) + Mathf.Pow(deltaY, 2) > Mathf.Pow(m_rootWidth, 2))
        {
            if (Mathf.Abs(deltaX) > m_rootWidth)
            {
                if (deltaX > 0)
                {
                    deltaX = m_rootWidth / Mathf.Sqrt(Mathf.Pow(Mathf.Abs(deltaY/deltaX), 2) + 1.0f); 
                }
                else
                    deltaX = -(m_rootWidth / Mathf.Sqrt(Mathf.Pow(Mathf.Abs(deltaY/deltaX), 2) + 1.0f));
            }

            if (Mathf.Abs(deltaY) > m_rootWidth)
            {
                if (deltaY > 0)
                {
                    deltaY = m_rootWidth / Mathf.Sqrt(Mathf.Pow(Mathf.Abs(deltaX/deltaY), 2) + 1.0f); 
                }
                else
                    deltaY = -(m_rootWidth / Mathf.Sqrt(Mathf.Pow(Mathf.Abs(deltaX/deltaY), 2) + 1.0f));
            }
        }
        m_thumbRectTrans.anchoredPosition = new Vector2(deltaX, deltaY);

        Debug.Log("OnDrag was called");
    }
}
