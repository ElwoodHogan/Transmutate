using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BM_Sticky : BlockMod
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<RigidbodyController>().enabled = false;
            collision.gameObject.GetComponent<StickyMovement>().enabled = true;
            collision.gameObject.GetComponent<StickyMovement>().stickyBlock = gameObject.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<RigidbodyController>().enabled = true;
            collision.gameObject.GetComponent<StickyMovement>().enabled = false;
        }
    }


}
