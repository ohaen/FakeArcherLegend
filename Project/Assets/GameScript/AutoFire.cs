using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
    public GameObject attackBullet;
    public GameObject bulletPosition;

    public GameObject TwinBulletPosition1;
    public GameObject TwinBulletPosition2;

    private GameObject _temp;

    private PlayerInfomation _playerInformation;


    private Animator _playerAnimator;


    void Start()
    {
        _playerInformation = GetComponent<PlayerInfomation>();
        _playerAnimator = GetComponent<Animator>();
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
            _temp = Instantiate(attackBullet, TwinBulletPosition1.transform.position, transform.rotation);
            _temp.GetComponent<Bullet>().damage = playerDamage;
            _temp = Instantiate(attackBullet, TwinBulletPosition2.transform.position, transform.rotation);
            _temp.GetComponent<Bullet>().damage = playerDamage;
        }
        else
        {
            _temp = Instantiate(attackBullet, bulletPosition.transform.position, transform.rotation);
            _temp.GetComponent<Bullet>().damage = playerDamage;
        }
    }
}
