using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float strafeSpeed;
    [SerializeField] float jumpForce;
    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) _rb.velocity += new Vector3(0, jumpForce, 0);
    }
    private void FixedUpdate()
    {
        float yVelocity = _rb.velocity.y;
        if (Input.GetKey(KeyCode.W)) _rb.velocity = (transform.forward * moveSpeed) + new Vector3(0, yVelocity, 0);
        if (Input.GetKey(KeyCode.S)) _rb.velocity = (-transform.forward * moveSpeed) + new Vector3(0, yVelocity, 0);
        if (Input.GetKey(KeyCode.A)) _rb.velocity = (-transform.right * moveSpeed) + new Vector3(0, yVelocity, 0);
        if (Input.GetKey(KeyCode.D)) _rb.velocity = (transform.right * moveSpeed) + new Vector3(0, yVelocity, 0);
    }
}
