
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(RectTransform))]
public class MyJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    public RectTransform joystick;
    public Vector2 autoReturnSpeed = new Vector2(4.0f, 4.0f);
    public float radius = 40.0f;
    
    public event Action<MyJoystick, Vector2> OnStartJoystickMovement;
    public event Action<MyJoystick, Vector2> OnJoystickMovement;
    public event Action<MyJoystick> OnEndJoystickMovement;
    
    private bool _returnJoystick;
    private RectTransform _touchZone;
    private Vector2 _resolutionCorrection;
    
    public Vector2 Coordinates
    {
        get
        {
            if (joystick.localPosition.magnitude < radius)
                return joystick.localPosition / radius;
            return joystick.localPosition.normalized;
        }
    }
    
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        _returnJoystick = false;
        var joystickOffset = GetJoystickOffset(eventData);
        joystick.localPosition = joystickOffset;
        if (OnStartJoystickMovement != null)
            OnStartJoystickMovement(this, Coordinates);
    }
    
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        var joystickOffset = GetJoystickOffset(eventData);
        joystick.localPosition = joystickOffset;
        if (OnJoystickMovement != null)
            OnJoystickMovement(this, Coordinates);
    }
    
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        _returnJoystick = true;
        if (OnEndJoystickMovement != null)
            OnEndJoystickMovement(this);
    }
    
    private Vector2 GetJoystickOffset(PointerEventData eventData)
    {
        var eventDataPos = new Vector2(eventData.position.x * _resolutionCorrection.x, eventData.position.y * _resolutionCorrection.y);
        var joystickOffset3D = _touchZone.TransformPoint(eventDataPos) - _touchZone.position * 2;
        var joystickOffset = new Vector2(joystickOffset3D.x, joystickOffset3D.y);
        if (joystickOffset.magnitude > radius)
            joystickOffset = joystickOffset.normalized * radius;
        joystick.localPosition = joystickOffset;
        return joystickOffset;
    }
    
    private void Start()
    {
        _returnJoystick = true;
        _touchZone = GetComponent<RectTransform>();
        _touchZone.pivot = Vector2.one * 0.5f;
        joystick.transform.parent = transform;
        _resolutionCorrection = Vector2.one;
        CanvasScaler rRes;
        for (var i = transform; i != null; i = i.parent)
        {
            if ((rRes = i.GetComponent<CanvasScaler>()) != null)
            {
                var res = rRes.referenceResolution;
                _resolutionCorrection = new Vector2(res.x / Screen.width, res.y / Screen.height);
                break;
            }
        }
    }
    
    private void Update()
    {
        if (_returnJoystick && joystick.localPosition.magnitude > Mathf.Epsilon)
            joystick.localPosition -= new Vector3(joystick.localPosition.x * autoReturnSpeed.x, joystick.localPosition.y * autoReturnSpeed.y, 0.0f) * Time.deltaTime;
    }
}