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
        // TODO: 컴포넌트 연결
    }

    private void Update()
    {
        // Input 처리
        Vector3 movement = new Vector3(_movementInput.x, 0, _movementInput.y);
        movement.Normalize();
        
        // TODO: _movementInput 을 이용하여 이동해보자
        
        // TODO: 회전을 적용해보자
        
        // TODO: 애니메이션 파라미터를 이용해 애니메이션을 적용해보자
    }
    
    
    private void OnMove(InputValue value)
    {
        _movementInput = value.Get<Vector2>();
    }
    
    private void OnJump()
    {
        // TODO: Rigidbody 를 이용해서 Jump를 구현해보자
    }
}
