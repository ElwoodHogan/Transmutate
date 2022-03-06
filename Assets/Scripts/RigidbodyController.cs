using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour
{
    [SerializeField] LayerMask FloorMask;
    [SerializeField] LayerMask Shootable;
    [SerializeField] Rigidbody PlayerBody;
    [SerializeField] Transform HeadCheck;
    [SerializeField] Transform GroundCheck;
    [SerializeField] CapsuleCollider PlayerCollider;
    [SerializeField] Transform Camera;
    public float Speed;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityScale = 1;
    float CUSTOM_GRAVITY { get { return -9.81f * gravityScale; } }

    Vector3 MovementInput;

    bool crouched = false;

    public Vector3 velocityBeforePhysicsUpdate { get; private set;  }

    private void Update()
    {
        MovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(MovementInput) * Speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Physics.CheckSphere(GroundCheck.position, .1f, FloorMask)
                || Physics.CheckSphere(GroundCheck.position, .1f, Shootable))
            PlayerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            crouched = true;
            PlayerCollider.height = 1;
            PlayerCollider.center = new Vector3(0, -.5f, 0);
            Camera.localPosition = new Vector3(0,-.5f,0);
        }
        else if(!Physics.CheckSphere(HeadCheck.position, .445f))
        {
            crouched = false;
            PlayerCollider.height = 2;
            PlayerCollider.center = Vector3.zero;
            Camera.localPosition = new Vector3(0, .5f, 0);
        }

        if(crouched) MoveVector *= .5f;

        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);
    }

    private void FixedUpdate()
    {
        PlayerBody.AddForce(Vector3.up * CUSTOM_GRAVITY, ForceMode.Acceleration);
        velocityBeforePhysicsUpdate = PlayerBody.velocity;
    }

    [Space]
    [SerializeField] float GizmoLineDistance = 1;
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(HeadCheck.position, GizmoLineDistance);
    }
}
