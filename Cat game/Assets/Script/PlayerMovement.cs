using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float sprintingSpeed = 8.0f;
    [SerializeField] private float rotationSpeed = 270.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float rayCastLength = 0.7f;
    [SerializeField] private float rayCastY = 0.1f;
    
    private Vector2 _inputValue;
    private Rigidbody _rigidbody;
    private bool _isSprinting;
    public bool Locked;

    private void Start()
    {
        Locked = false;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue inputValue)
    {
        _inputValue = inputValue.Get<Vector2>();
    }

    private void OnJump()
    {
        if (!IsGrounded()) return;
        
        _rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position + new Vector3(0f, rayCastY, 0f), -transform.up, rayCastLength);
    }

    private void OnSprint()
    {
        _isSprinting = !_isSprinting;
    }

    private void FixedUpdate()
    {
        if (!Locked)
        {
            _rigidbody.MovePosition(
            transform.position + transform.forward * (_inputValue.y * (_isSprinting ? sprintingSpeed : movementSpeed) * Time.deltaTime)
        );

            _rigidbody.MoveRotation(
                transform.rotation *
                Quaternion.AngleAxis(rotationSpeed * Time.deltaTime * _inputValue.x, transform.up)
            );
        }
        
        
    }
}
