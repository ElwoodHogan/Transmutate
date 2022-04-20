using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyMovement : MonoBehaviour
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

    private void Update()
    {
        MovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f);

        if (Input.GetKey(KeyCode.W))
        {
            PlayerBody.velocity = new Vector3(PlayerBody.velocity.x, Speed, PlayerBody.velocity.z);
        }
        
        else if (Input.GetKey(KeyCode.S))
        {
            PlayerBody.velocity = new Vector3(PlayerBody.velocity.x, -Speed, PlayerBody.velocity.z);
        }

        else 
        {
            PlayerBody.velocity = new Vector3(PlayerBody.velocity.x, 0, PlayerBody.velocity.z);
        }

        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(MovementInput) * Speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerBody.AddForce(Camera.transform.forward.normalized * jumpForce, ForceMode.Impulse);
        }

        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);
    }

    private void FixedUpdate()
    {
        velocityBeforePhysicsUpdate = PlayerBody.velocity;
    }
}
