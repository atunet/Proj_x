using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;

public class MyJoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler 
{
    enum EState
    {
        IDLE,
        MOVING,
    };
    EState m_state;

    private RectTransform m_rectTrans;
    private Vector2 m_originPosition;
    private float m_movementRadius;     // 像素单位半径
    private float m_resetSpeed = 5.0f;  // 像素单位回归速度

    CrossPlatformInputManager.VirtualAxis m_horizontalVirtualAxis;  // Reference to the joystick in the cross platform input
    CrossPlatformInputManager.VirtualAxis m_verticalVirtualAxis;    // Reference to the joystick in the cross platform input


    void Start () 
    {      
        m_state = EState.IDLE;

        m_rectTrans = GetComponent<RectTransform>();
        m_originPosition = m_rectTrans.anchoredPosition;
        m_movementRadius = m_rectTrans.sizeDelta.x/2;

        Debug.Log("start called,origin position x:" + m_originPosition.x + ",y:" + m_originPosition.y + ",radius:" + m_movementRadius);
    }
	
    void OnEnable()
    {
        m_horizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis("Horizontal");
        CrossPlatformInputManager.RegisterVirtualAxis(m_horizontalVirtualAxis);

        m_verticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis("Vertical");
        CrossPlatformInputManager.RegisterVirtualAxis(m_verticalVirtualAxis);
    }

    void OnDisable()
    {
        m_horizontalVirtualAxis.Remove();
        m_verticalVirtualAxis.Remove();
    }

    void Update()
    {
        if (m_state == EState.IDLE)
        {
            if ((m_rectTrans.anchoredPosition - m_originPosition).magnitude > 0.3f)
            {
                m_rectTrans.anchoredPosition = Vector2.Lerp(m_rectTrans.anchoredPosition, m_originPosition, Time.deltaTime * m_resetSpeed);
            }
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("OnPointerDown was called");

        m_state = EState.MOVING;

        SetNewPos(data);

        UpdateVirtualAxes(m_rectTrans.anchoredPosition);
    }

    public void OnPointerUp(PointerEventData data)
    {
        Debug.Log("OnPointerUp was called");

        m_state = EState.IDLE;
    }

    public void OnDrag(PointerEventData data)
    {
        Debug.Log("OnDrag was called");

        SetNewPos(data);

        UpdateVirtualAxes(m_rectTrans.anchoredPosition);
    }

    private void SetNewPos(PointerEventData data)
    {
        Vector3 worldPos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_rectTrans, data.position, data.pressEventCamera, out worldPos))
        {
            m_rectTrans.position = worldPos;
        }
         
        Vector2 offset = m_rectTrans.anchoredPosition - m_originPosition;
        if (offset.magnitude > m_movementRadius)
        {
            offset = offset.normalized * m_movementRadius;
            m_rectTrans.anchoredPosition = offset;
        }
    }
        
    private void UpdateVirtualAxes(Vector2 value)
    {
        var delta = m_originPosition - value;
        delta.y = -delta.y;
        delta /= m_movementRadius;
       
        m_horizontalVirtualAxis.Update(-delta.x);
        m_verticalVirtualAxis.Update(delta.y);

        Debug.Log("Update virtual axes,x:" + -delta.x + ",y:" + delta.y);
    }
}
