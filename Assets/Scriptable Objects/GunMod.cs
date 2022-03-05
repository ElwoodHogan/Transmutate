using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GunMod : ScriptableObject
{
    public string ModName;
    public Image ModImage;
    public Material ModMaterial;
    public BlockMod BlockMod;

    public virtual void OnBlockShoot(Collider shotBlock) { }
}
