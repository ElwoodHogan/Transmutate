using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{




    //DEPRECIATED





    Vector3 _velocity;
    CharacterController _controller;
    bool _grounded;

    [SerializeField] float playerSpeed = 2;
    [SerializeField] float jumpHeight = 2;
    [SerializeField] float gravityScale = 1;
    float GRAVITY_VALUE { get{ return -9.81f * gravityScale; }}
    

    private void Awake()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerInput();

    }

    void PlayerInput()
    {
        _grounded = _controller.isGrounded;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * move;
        //move =Vector3.Scale(move, transform.forward);
        _controller.Move(move * (Time.deltaTime * playerSpeed));

        if(Input.GetButtonDown("Jump") && _grounded){
            _velocity.y = Mathf.Sqrt(jumpHeight * -3f * GRAVITY_VALUE);
        }
        else
        {
            _velocity.y += GRAVITY_VALUE * Time.deltaTime;
        }

        _controller.Move(_velocity * Time.deltaTime);
    }
}
