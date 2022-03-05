using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun Mods", menuName = "Bounce")]
public class GM_Bounce : GunMod
{
    public override void OnBlockShoot(Collider shotBlock)
    {
        shotBlock.GetComponent<Renderer>().material = ModMaterial;
        //shotBlock.material = ModPhysics;
    }
}


