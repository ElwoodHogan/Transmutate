using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gun Mods/Bounce")]
public class GM_Bounce : GunMod
{
    protected override void TransmuteBlock(Collider shotBlock)
    {
        shotBlock.gameObject.AddComponent<BM_Bounce>();
    }
}


