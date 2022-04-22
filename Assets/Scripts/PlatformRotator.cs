using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformRotator : MonoBehaviour
{
    public void TriggerPlatform()
    {
        transform.DORotate(new Vector3(0,90,24), 1);
        //transform.rotation = Quaternion.Euler(0,0,24);
    }
}
