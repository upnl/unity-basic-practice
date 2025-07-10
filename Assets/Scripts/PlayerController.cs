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

    private bool _isGrounded;

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
        Vector3 movement = new Vector3(_movementInput.x, 0, _movementInput.y);
        movement.Normalize();
        
        transform.Translate(movement * (speed * Time.deltaTime));
        
        if (movement.magnitude >= 0.1f)
            _animator.transform.rotation = 
                Quaternion.Lerp(_animator.transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * 10f);
        
        _animator.SetBool("IsMoving", _movementInput != Vector2.zero);
        
        // TODO: _isGrounded 을 이용하여 애니메이션을 적용해보자
        _animator.SetBool("IsGrounded", _isGrounded);
    }
    
    
    private void OnMove(InputValue value)
    {
        _movementInput = value.Get<Vector2>();
    }

    // TODO: _isGrounded 을 이용해 무한 점프를 방지
    private void OnJump()
    {
        if (_isGrounded)
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    
    // TODO: _isGrounded 로 상태 추적 (OnCollisionEnter, OnCollisionExit 을 이용해보자)
    // TODO: Enemy 태그를 이용하여 간단한 게임 오버를 만들어보자
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}
