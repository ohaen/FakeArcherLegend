using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    
    private Rigidbody _playerRigidbody;
    private Animator _playerAnimator;
    private PlayerInput _playerInput;
    private PlayerInfomation _playerInfomation;

    private Vector3 _moveVec;


    void Start()
    {
        _playerInfomation = GetComponent<PlayerInfomation>();
        _playerRigidbody = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        _moveVec = MoveVec();

        _playerAnimator.SetBool("Attack", false);
        _playerAnimator.SetBool("Run", _moveVec != Vector3.zero);
        
        
        _playerRigidbody.velocity = MoveVec() * (_playerInfomation.moveSpeed + ((_playerInfomation.moveSpeed * 0.1f) * _playerInfomation.moveSpeedUpCount));
        
    }
    public Vector3 MoveVec()
    { 
        return new Vector3(_playerInput._horizontal, 0, _playerInput._vertical).normalized;
    }
    
}
