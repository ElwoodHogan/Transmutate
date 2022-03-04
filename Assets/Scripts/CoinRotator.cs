using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    public float RotateSpeed;

    private void Update()
    {
        transform.eulerAngles += new Vector3(0, RotateSpeed, 0);
    }
}
