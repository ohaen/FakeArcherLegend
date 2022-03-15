using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
    public GameObject attackBullet;
    public GameObject attackBullet2;

    private GameObject _selectWeapon;

    public GameObject bulletPosition;

    public GameObject TwinBulletPosition1;
    public GameObject TwinBulletPosition2;

    private GameObject _temp;

    private PlayerInfomation _playerInformation;


    private Animator _playerAnimator;


    void Start()
    {
        _selectWeapon = attackBullet;
        _playerInformation = GetComponent<PlayerInfomation>();
        _playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey("1"))
        {
            ChangeWeapon(0);
        }
        else if (Input.GetKey("2"))
        {
            ChangeWeapon(1);
        }
    }

    public void ChangeWeapon(int select)
    {
        switch (select)
        {
            case 0:
                _selectWeapon = attackBullet;
                break;
            case 1:
                _selectWeapon = attackBullet2;
                break;
        }
    }

    public void Fire()
    {
        MakeBull();
        if (_playerInformation.doubleAttack == true)
        {
            Invoke("MakeBull", 0.15f);
        }
    }
    void MakeBull()
    {
        float playerDamage = _playerInformation.CalcDamage();
        float playerAttackSpeed = _playerInformation.attackSpeed + (_playerInformation.attackSpeedUpCount * 0.1f);
        _playerAnimator.SetFloat("AttackSpeed", playerAttackSpeed);
        if (_playerInformation.twinAttack)
        {
            _temp = Instantiate(_selectWeapon, TwinBulletPosition1.transform.position, transform.rotation);
            _temp.GetComponent<BullBase>().damage = playerDamage;
            _temp = Instantiate(_selectWeapon, TwinBulletPosition2.transform.position, transform.rotation);
            _temp.GetComponent<BullBase>().damage = playerDamage;
        }
        else
        {
            _temp = Instantiate(_selectWeapon, bulletPosition.transform.position, transform.rotation);
            _temp.GetComponent<BullBase>().damage = playerDamage;
        }
        if (_playerInformation.sideAttack)
        {
            _temp = Instantiate(_selectWeapon, TwinBulletPosition1.transform.position, transform.rotation);
            _temp.transform.Rotate(0, 45.0f, 0);
            _temp.GetComponent<BullBase>().damage = playerDamage;
            _temp = Instantiate(_selectWeapon, TwinBulletPosition1.transform.position, transform.rotation);
            _temp.transform.Rotate(0, -45.0f, 0);
            _temp.GetComponent<BullBase>().damage = playerDamage;
        }
    }
}
