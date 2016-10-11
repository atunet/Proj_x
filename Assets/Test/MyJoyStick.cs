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
    private float m_movementRadius;     // 像素单位
    private float m_resetSpeed = 500.0f; 

    CrossPlatformInputManager.VirtualAxis m_horizontalVirtualAxis;  // Reference to the joystick in the cross platform input
    CrossPlatformInputManager.VirtualAxis m_verticalVirtualAxis;    // Reference to the joystick in the cross platform input


    void Start () 
    {      
        m_state = EState.IDLE;

        m_rectTrans = GetComponent<RectTransform>();
        m_originPosition = m_rectTrans.anchoredPosition;
        m_movementRadius = m_rectTrans.sizeDelta.x/2;

        Debug.Log("start called,origin position x:" + m_originPosition.x + ",y:" + m_originPosition.y + ",radius:" + m_movementRadius);


        Vector3 t1 = new Vector3(0.000000001f, 0.000000001f, 0.00000000f);
        Vector3 t2 = t1.normalized;
        Debug.Log(t1.ToString());
        Debug.Log(t2.ToString());
        Debug.Log(t1.magnitude);
        Debug.Log(t1.sqrMagnitude);

        t1.Normalize();
        Debug.Log(t1.ToString());
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
            if ((m_rectTrans.anchoredPosition - m_originPosition).magnitude > 0.1f)
            {
                Vector2 offset = m_rectTrans.anchoredPosition - m_originPosition;
                //Vector2.Lerp(m_rectTrans.anchoredPosition, m_originPosition, Time.deltaTime * m_resetSpeed);
                m_rectTrans.anchoredPosition -= offset.normalized * Time.deltaTime * m_resetSpeed;
            }
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("OnPointerDown was called");

        m_state = EState.MOVING;

        SetNewPos(data);
    }

    public void OnPointerUp(PointerEventData data)
    {
        Debug.Log("OnPointerUp was called");

        m_state = EState.IDLE;

        //m_rectTrans.position = m_originPosition;
    }

    public void OnDrag(PointerEventData data)
    {
        Debug.Log("OnDrag was called");

        SetNewPos(data);

        // http://blog.csdn.net/qq992817263/article/details/50925802

       /* Vector2 newPos = Vector2.zero;
        CalcNewPos(data.delta, out newPos);
        m_thumbTrans.anchoredPosition = newPos;
        Debug.Log("OnDrag new pos:" + newPos.x + "," + newPos.y);

        UpdateVirtualAxes(m_thumbTrans.anchoredPosition);

        PrintPointerEventData(data);
        */
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

   /* Vector2 NormalizedOffset(Vector2 offset)
    {
        return (offset.magnitude < m_movementRadius) ? (offset.normalized / m_movementRadius) : offset.normalized;
    }*/

    private void UpdateVirtualAxes(Vector2 value)
    {
        var delta = m_originPosition - value;
        delta.y = -delta.y;
        delta /= m_movementRadius;
       
        m_horizontalVirtualAxis.Update(-delta.x);
        m_verticalVirtualAxis.Update(delta.y);
    }
}
