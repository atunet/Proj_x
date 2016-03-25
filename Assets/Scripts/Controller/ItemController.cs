using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D c2d_)
    {
        Collider2D c2d = this.gameObject.GetComponent<Collider2D>();
        if (c2d && c2d.isTrigger)
        {
            //GlobalRef.s_gr.PlaySound(ESound.SOUND_ITEM_COLLISION);

            Destroy(this.gameObject);
        }
    }
}
