using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour
{
    [SerializeField] Rigidbody BallBody;
    public Vector3 velocityBeforePhysicsUpdate { get; private set; }
    private void FixedUpdate()
    {
        velocityBeforePhysicsUpdate = BallBody.velocity;
    }

}
