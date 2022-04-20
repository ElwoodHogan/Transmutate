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

    bool tryingToJump = false;
    bool tryingToCrouch = false;

    [SerializeField] AnimationCurve movementCurve;
    [SerializeField] float curveMulti;

    public Vector3 velocityBeforePhysicsUpdate { get; private set;  }

    [SerializeField] bool grounded;

    private void Update()
    {
        MovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        tryingToJump = Input.GetKey(KeyCode.Space);

        tryingToCrouch = (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl));

    }
    private void FixedUpdate()
    {
        PlayerBody.AddForce(Vector3.up * CUSTOM_GRAVITY, ForceMode.Acceleration);
        velocityBeforePhysicsUpdate = PlayerBody.velocity;
        grounded = (Physics.CheckSphere(GroundCheck.position, .1f, FloorMask)
                || Physics.CheckSphere(GroundCheck.position, .1f, Shootable)) ;

            MovePlayer();
    }

    void MovePlayer()
    {
        MovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        if (tryingToJump)
        {
            if(grounded)
            PlayerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (tryingToCrouch)
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


        if (grounded)
        {
            PlayerBody.velocity = (Vector3.Normalize((transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"))) * Speed) + new Vector3(0,PlayerBody.velocity.y,0);
            print((Vector3.Normalize((transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"))) * Speed) + new Vector3(0, PlayerBody.velocity.y, 0));
        }
        else
        {
            Vector3 MoveDir = Vector3.Normalize((transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"))) * Speed;
            float LerpedMovement = InverseLerp(Vector3.zero,
                MoveDir,
                PlayerBody.velocity);
            if (!float.IsNaN(LerpedMovement))
            {
                if (LerpedMovement < 0) LerpedMovement = 0;
                LerpedMovement = Mathf.Round(LerpedMovement * 100f) / 100f;

                float MoveModifier = movementCurve.Evaluate(Mathf.Abs(LerpedMovement)) * curveMulti;
                Vector3 forceToAdd3 = MoveDir * MoveModifier;
                
                //print(LerpedMovement + " " + MoveDir + " " + forceToAdd3);
                PlayerBody.AddForce(forceToAdd3, ForceMode.Acceleration);
            }
            else
            {
                PlayerBody.velocity = new Vector3(PlayerBody.velocity.x * .9f, PlayerBody.velocity.y, PlayerBody.velocity.z * .9f);
            }
        }
    }

    

    [Space]
    [SerializeField] float GizmoLineDistance = 1;
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(HeadCheck.position, GizmoLineDistance);
    }

    public static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
    {
        Vector3 AB = b - a;
        Vector3 AV = value - a;
        return Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB);
    }

     public Vector3 Abs(Vector3 inp)
    {
        return new Vector3(Mathf.Abs(inp.x), Mathf.Abs(inp.y), Mathf.Abs(inp.z));
    }
}
