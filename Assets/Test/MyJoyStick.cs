using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;

public class MyJoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler 
{
    public int m_movementRadius = 90;

    private RectTransform m_thumbTrans;
    private Vector2 m_thumbOriginPosition;

    CrossPlatformInputManager.VirtualAxis m_horizontalVirtualAxis;  // Reference to the joystick in the cross platform input
    CrossPlatformInputManager.VirtualAxis m_verticalVirtualAxis;    // Reference to the joystick in the cross platform input


    void Start () 
    {
        RectTransform tempTrans = (RectTransform)transform;
        Debug.Log("start parent anchored position:" + tempTrans.anchoredPosition.x + "," + tempTrans.anchoredPosition.y);

        m_thumbTrans = transform.FindChild("thumb") as RectTransform;
        m_thumbOriginPosition = m_thumbTrans.anchoredPosition;

        Debug.Log("start called,origin position x:" + m_thumbOriginPosition.x + ",y:" + m_thumbOriginPosition.y);
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

    public void OnPointerDown(PointerEventData data)
    {
        Vector2 newPos = Vector2.zero;
        CalcNewPos(data.delta, out newPos);
        m_thumbTrans.anchoredPosition = newPos;
        Debug.Log("OnPointerDown new pos:" + newPos.x + "," + newPos.y);
        UpdateVirtualAxes(m_thumbTrans.anchoredPosition);
        PrintPointerEventData(data);
    }

    public void OnPointerUp(PointerEventData data)
    {
        m_thumbTrans.anchoredPosition = m_thumbOriginPosition;
        Debug.Log("OnPointerUp was called");
    }

    public void OnDrag(PointerEventData data)
    {
        Vector2 newPos = Vector2.zero;
        CalcNewPos(data.delta, out newPos);
        m_thumbTrans.anchoredPosition = newPos;
        Debug.Log("OnDrag new pos:" + newPos.x + "," + newPos.y);

        UpdateVirtualAxes(m_thumbTrans.anchoredPosition);

        PrintPointerEventData(data);
    }

    private void CalcNewPos(Vector2 clickPos, out Vector2 newPos)
    {
        float distance = Vector2.Distance(clickPos, m_thumbOriginPosition);
        if (distance > m_movementRadius)
        {
            newPos.x = (m_movementRadius / distance) * (clickPos.x - m_thumbOriginPosition.x);
            newPos.y = (m_movementRadius / distance) * (clickPos.y - m_thumbOriginPosition.y);
        }
        else
        {
            newPos.x = clickPos.x - m_thumbOriginPosition.x;
            newPos.y = clickPos.y - m_thumbOriginPosition.y;
        }
    }

    private void UpdateVirtualAxes(Vector2 value)
    {
        var delta = m_thumbOriginPosition - value;
        delta.y = -delta.y;
        delta /= m_movementRadius;
       
        m_horizontalVirtualAxis.Update(-delta.x);
        m_verticalVirtualAxis.Update(delta.y);
    }

    private void PrintPointerEventData(PointerEventData data)
    {
        Debug.Log("/////////////////////////////");
        Debug.Log("PrintPointerEventData position," + data.position.x + "," + data.position.y);
        Debug.Log("PrintPointerEventData press position," + data.pressPosition.x + "," + data.pressPosition.y);
        Debug.Log("PrintPointerEventData delta," + data.delta.x + "," + data.delta.y);
        Debug.Log("PrintPointerEventData screenposition:" + data.pointerCurrentRaycast.screenPosition.x + "," + data.pointerCurrentRaycast.screenPosition.y);
        Debug.Log("PrintPointerEventData worldposition:" + data.pointerCurrentRaycast.worldPosition.x + "," + data.pointerCurrentRaycast.worldPosition.y);
        Debug.Log("/////////////////////////////");
    }
}
