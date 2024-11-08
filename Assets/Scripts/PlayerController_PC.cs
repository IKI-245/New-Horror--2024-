using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_PC : MonoBehaviour
{
    public float gravity = 9.8f;
    public float speed = 6;

    private float _fallVelocity = 0;
    private CharacterController _characterController;
    private Vector3 _moveVector;
    private Animator _animator;


    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MovementUpdate();
    }

    private void MovementUpdate()
    {
        _moveVector = Vector3.zero;
        var walkDirection = 0;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            walkDirection = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            walkDirection = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            walkDirection = 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            walkDirection = 1;
        }
        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.LeftShift)))
        {
            _moveVector += transform.forward;
            walkDirection = 3;
        }
        _animator.SetInteger("walk direction", walkDirection);
    }
    void FixedUpdate()
    {
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.deltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
