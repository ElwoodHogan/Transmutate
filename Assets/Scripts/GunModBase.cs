using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunModBase : MonoBehaviour
{
    public Material ModMaterial;
    public PhysicMaterial ModPhysics;
    public virtual void OnBlockShoot(Collider shotBlock) { }
}
