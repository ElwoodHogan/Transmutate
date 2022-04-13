using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunMod : ScriptableObject
{
    public string ModName;
    public Sprite ModImage;
    public Material ModMaterial;
    public virtual void OnBlockShoot(Collider shotBlock) {
        shotBlock.gameObject.GetComponent<Renderer>().material = ModMaterial;
        TransmuteBlock(shotBlock);
    }

    protected abstract void TransmuteBlock(Collider shotBlock);
}
