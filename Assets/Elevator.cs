using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Elevator : MonoBehaviour
{
    bool lifted = false;
    Vector3 startPos;
    Rigidbody _rb;
    [SerializeField] Transform endPos;
    [SerializeField] float liftTime = 1;
    [SerializeField] bool lift;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    private void Update()
    {
        if (lift)
        {
            Lift();
            lift = false;
        }
    }
    public void Lift()
    {
        if (!lifted)
        {
            _rb.DOMoveY(endPos.position.y, liftTime);
        }
        else
        {
            _rb.DOMoveY(startPos.y, liftTime);
        }
        lifted = !lifted;
    }
}
