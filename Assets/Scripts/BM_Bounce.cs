using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BM_Bounce : BlockMod
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = 
                collision.gameObject.GetComponent<RigidbodyController>().velocityBeforePhysicsUpdate * -1f;
        }
        if (collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity =
                collision.gameObject.GetComponent<BounceBall>().velocityBeforePhysicsUpdate
                .Change(0, collision.gameObject.GetComponent<BounceBall>().velocityBeforePhysicsUpdate.y*(-2f), 0);
        }
    }
}
