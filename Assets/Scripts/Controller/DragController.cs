using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 m_beginPos;
    private Vector2 m_endPos;
    private EDirection m_dir;

    public void OnDrag(PointerEventData data_)
    {
    }

    public void OnBeginDrag(PointerEventData data_)
    {
        m_beginPos = new Vector2(data_.position.x, data_.position.y);
    }

    public void OnEndDrag(PointerEventData data_)
    {
        m_endPos = new Vector2(data_.position.x, data_.position.y);

        Vector2 deltaPos = m_endPos - m_beginPos;       
        if (deltaPos.x > 0)
        {
            if (Mathf.Abs(deltaPos.y) <= deltaPos.x)
                m_dir = EDirection.DIR_EAST;
            else
            {
                if (deltaPos.y > 0)
                    m_dir = EDirection.DIR_NORTH;
                else if (deltaPos.y < 0)
                    m_dir = EDirection.DIR_SOUTH;
            }
        } else if (deltaPos.x == 0)
        {
            if (deltaPos.y > 0)
                m_dir = EDirection.DIR_NORTH;
            else
                m_dir = EDirection.DIR_SOUTH;
        } else
        {
            if(Mathf.Abs(deltaPos.y) <= Mathf.Abs(deltaPos.x))
                m_dir = EDirection.DIR_WEST;
            else
            {
                if (deltaPos.y > 0)
                    m_dir = EDirection.DIR_NORTH;
                else if (deltaPos.y < 0)
                    m_dir = EDirection.DIR_SOUTH;
            }
        }

        Debug.Log("Drag direction:" + m_dir);
       
        if (m_dir == EDirection.DIR_NORTH)
        {
            RocketController controller = PlayController.s_rocketTrans.gameObject.GetComponent<RocketController>();
           
            controller.speedy = true;

            Debug.Log("rocket speedy:" + controller.speedy);

        } else if (m_dir == EDirection.DIR_SOUTH)
        {     
            RocketController controller = PlayController.s_rocketTrans.gameObject.GetComponent<RocketController>();
            
            controller.speedy = false;

            Debug.Log("rocket speedy:" + controller.speedy);

        } else if (m_dir == EDirection.DIR_EAST)
        {
            //PlayController.s_rocketTrans.gameObject.GetComponent<Rigidbody2D>().AddTorque(-10000f);
            PlayController.s_rocketTrans.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(1000f, 0f), new Vector2(-1f, 0f));

        } else if (m_dir == EDirection.DIR_WEST)
        {
            //PlayController.s_rocketTrans.gameObject.GetComponent<Rigidbody2D>().AddTorque(10000f);
            PlayController.s_rocketTrans.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(-1000f, 0f), new Vector2(1f, 0f));

        }
    }
}
