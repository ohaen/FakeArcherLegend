using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //public float MoveSpeed = 5f;

    
    private Rigidbody _playerRigidbody;
    private Animator _playerAnimator;
    private PlayerInput _playerInput;

    private Vector3 _moveVec;


    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        _moveVec = MoveVec();

        _playerAnimator.SetBool("Attack", false);
        _playerAnimator.SetBool("Run", _moveVec != Vector3.zero);
        
        
        _playerRigidbody.velocity = MoveVec() * gameObject.GetComponent<LivingEntity>().moveSpeed;
        
    }
    public Vector3 MoveVec()
    { 
        return new Vector3(_playerInput._horizontal, 0, _playerInput._vertical).normalized;
    }
    
}
