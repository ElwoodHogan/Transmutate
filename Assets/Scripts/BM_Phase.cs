using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BM_Phase : BlockMod
{
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<RigidbodyController>().Speed =
                25f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<RigidbodyController>().Speed =
                5f;
        }
    }
}
