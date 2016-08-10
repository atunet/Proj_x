using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DirectController : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData data_)
    {
        if (gameObject.name == "UpBtn")
        {
            PlayController.s_rocketController.UpPressed = true;

        } else if (gameObject.name == "DownBtn")
        {
            PlayController.s_rocketController.DownPressed = true;

        } else if (gameObject.name == "LeftBtn")
        {
            PlayController.s_rocketController.LeftPressed = true;

        } else if (gameObject.name == "RightBtn")
        {
            PlayController.s_rocketController.RightPressed = true;
        }

        Debug.Log("OnPointerDown gameobject name:" + gameObject.name);
    }

    public void OnPointerUp(PointerEventData data_)
    {
        if (gameObject.name == "UpBtn")
        {
            PlayController.s_rocketController.UpPressed = false;

        } else if (gameObject.name == "DownBtn")
        {
            PlayController.s_rocketController.DownPressed = false;

        } else if (gameObject.name == "LeftBtn")
        {
            PlayController.s_rocketController.LeftPressed = false;

        } else if (gameObject.name == "RightBtn")
        {
            PlayController.s_rocketController.RightPressed = false;
        }

        Debug.Log("OnPointerUp gameobject name:" + gameObject.name);
    }
}
