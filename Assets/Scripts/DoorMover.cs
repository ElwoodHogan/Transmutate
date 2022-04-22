using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorMover : MonoBehaviour
{
    public Transform StartPoint;
    public Vector3 endPoint;

    private void Awake()
    {
        endPoint = transform.position;
    }
    public void StartMovement(float time)
    {
        transform.DOMove(StartPoint.position, 2).OnComplete(()=> transform.DOMove(endPoint, time));
    }
}
