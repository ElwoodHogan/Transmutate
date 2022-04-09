using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gun Mods/Phase")]
public class GM_Phase : GunMod
{
    protected override void TransmuteBlock(Collider shotBlock)
    {
        shotBlock.gameObject.AddComponent<BM_Phase>();
    }
}


