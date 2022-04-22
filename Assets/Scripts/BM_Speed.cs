using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BM_Speed : BlockMod
{

    private void Start()
    {
        RaycastHit hit;
        if (Physics.Raycast(FrontMan.FM.Player.transform.position, Vector3.down, out hit, 4, FrontMan.FM.Shootable))
        {
            if (hit.collider.gameObject == gameObject)
            {
                FrontMan.FM.Player.GetComponent<RigidbodyController>().Speed =
                20f;
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<RigidbodyController>().Speed =
                20f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<RigidbodyController>().Speed =
                7f;
        }
    }
}
