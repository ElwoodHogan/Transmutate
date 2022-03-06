using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pusher : MonoBehaviour
{
    [SerializeField]Transform EndPoint, StartPoint;
    [SerializeField] float moveTime;

    private void Start()
    {
        GetComponent<Rigidbody>().DOPath(new Vector3[] { StartPoint.position, EndPoint.position, StartPoint.position }, moveTime).SetLoops(-1);
    }
}
