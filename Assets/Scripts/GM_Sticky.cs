using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gun Mods/Sticky")]
public class GM_Sticky : GunMod
{
    protected override void TransmuteBlock(Collider shotBlock)
    {
        shotBlock.gameObject.AddComponent<BM_Sticky>();
    }
}

