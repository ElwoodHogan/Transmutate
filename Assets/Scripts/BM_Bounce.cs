using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BM_Bounce : BlockMod
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent
        }
    }
}
