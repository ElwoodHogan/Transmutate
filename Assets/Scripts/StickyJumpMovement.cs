using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyJumpMovement : MonoBehaviour
{
    [SerializeField] LayerMask Shootable;
    [SerializeField] Rigidbody PlayerBody;
    [SerializeField] Transform GroundCheck;
    [SerializeField] CapsuleCollider PlayerCollider;
    [SerializeField] Transform Camera;
    public float Speed;
    [SerializeField] float jumpForce;
    Vector3 MovementInput;
    public Transform stickyBlock; 
    public Vector3 velocityBeforePhysicsUpdate { get; private set;  }
    [SerializeField] RigidbodyController rigidbodyController;
    public Vector3 jumpVelocity;

    private void Update()
    {
        if (jumpVelocity != new Vector3(0, 0, 0))
        {
            PlayerBody.velocity = jumpVelocity;
            jumpVelocity = new Vector3(0, 0, 0);
        }
        
        MovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(MovementInput) * Speed;

        PlayerBody.velocity = new Vector3(PlayerBody.velocity.x + MoveVector.x, PlayerBody.velocity.y, PlayerBody.velocity.z + MoveVector.z);
    }

    private void FixedUpdate()
    {
        velocityBeforePhysicsUpdate = PlayerBody.velocity;
    }
}
