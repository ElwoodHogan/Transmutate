using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Bounce : GunModBase
{
    public override void OnBlockShoot(Collider shotBlock)
    {
        shotBlock.GetComponent<Renderer>().material = ModMaterial;
        shotBlock.material = ModPhysics;
    }
    
}


