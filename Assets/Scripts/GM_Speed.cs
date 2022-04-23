using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gun Mods/Speed")]
public class GM_Speed : GunMod
{
    protected override void TransmuteBlock(Collider shotBlock)
    {
        shotBlock.gameObject.AddComponent<BM_Speed>();
        FindObjectOfType<RigidbodyController>().Speed = 7f;
    }
}


