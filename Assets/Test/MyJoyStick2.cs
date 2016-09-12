using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;

public class MyJoyStick2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler 
{
    enum State
    {
        IDLE,
        MOVING,
    }
    private State m_state;
    //private Animation m_character;
    public ThirdPersonCharacter m_character;
    private Vector3 m_move;

    public Transform m_camTrans;
    private Vector3 m_camForword;

    private Vector2 m_rootPostion;
    private float m_rootWidth;
    private float m_rootHeight;


    private RectTransform m_thumbRectTrans;
    private Vector2 m_thumbOriginPostion;


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
	
	void Update () 
    {
        if (m_state == State.IDLE)
        {
            if (m_thumbRectTrans.anchoredPosition != m_thumbOriginPostion)
            {
                //Mathf.ler
            }
        }
        else if (m_state == State.MOVING)
        {
        }
	}

    public void OnPointerDown(PointerEventData data)
    {
        m_state = State.MOVING;
        //m_character.Play("Moving");

        float dstX = 0f, dstY = 0f;
        CalcPos(data.position, out dstX, out dstY);
        m_thumbRectTrans.anchoredPosition = new Vector2(dstX, dstY);

        float v = 1, h = 1;
        if (m_camTrans != null)
        {
            // calculate camera relative direction to move:
            m_camForword = Vector3.Scale(m_camTrans.forward, new Vector3(1, 0, 1)).normalized;
            m_move = v*m_camForword + h*m_camTrans.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            m_move = v*Vector3.forward + h*Vector3.right;
        }
        m_character.Move(m_move, false, false);

        Debug.Log("OnPointerDown position," + data.position.x + "," + data.position.y + "delta:" + dstX + "," + dstY);
    }

    public void OnPointerUp(PointerEventData data)
    {
        m_state = State.IDLE;
        //m_character.Play("Idle");

        m_thumbRectTrans.anchoredPosition = m_thumbOriginPostion;
        Debug.Log("OnPointerUp was called");
    }

    public void OnDrag(PointerEventData data)
    {
        float dstX = 0f, dstY = 0f;
        CalcPos(data.position, out dstX, out dstY);
        m_thumbRectTrans.anchoredPosition = new Vector2(dstX, dstY);

        Debug.Log("OnDrag was called," + data.position.x + "," + data.position.y + ",delta:" + dstX + "," + dstY);
    }

    private void CalcPos(Vector2 clickPos, out float dstX, out float dstY)
    {
        float distance = Vector2.Distance(clickPos, m_rootPostion);
        if (distance > m_rootWidth)
        {
            dstX = (m_rootWidth / distance) * (clickPos.x - m_rootPostion.x);
            dstY = (m_rootHeight / distance) * (clickPos.y - m_rootPostion.y);
        }
        else
        {
            dstX = clickPos.x - m_rootPostion.x;
            dstY = clickPos.y - m_rootPostion.y;
        }
    }
}
