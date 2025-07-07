using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // public members
    public float speed;
    public float jumpForce;
    
    // private members
    private Vector2 _movementInput;

    // components
    private Animator _animator;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // TODO: _movementInput 을 이용하여 이동해보자
        Vector3 movement = new Vector3(_movementInput.x, 0, _movementInput.y);
        movement.Normalize();
        
        transform.Translate(movement * (speed * Time.deltaTime));
        
        if (movement.magnitude >= 0.1f)
            _animator.transform.rotation = 
                Quaternion.Lerp(_animator.transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * 10f);
        
        // TODO: _movementInput 을 이용하여 애니메이션을 적용해보자
        _animator.SetBool("IsMoving", _movementInput != Vector2.zero);
    }
    
    
    private void OnMove(InputValue value)
    {
        _movementInput = value.Get<Vector2>();
    }

    // TODO: Rigidbody 를 이용해서 Jump를 구현해보자
    private void OnJump()
    {
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
