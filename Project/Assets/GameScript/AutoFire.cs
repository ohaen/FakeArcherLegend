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
        _playerAnimator.SetFloat("AttackSpeed", gameObject.GetComponent<LivingEntity>().attackSpeed);
        if (_playerInformation.twinAttack)
        {
            _temp = Instantiate(attackBullet, TwinBulletPosition1.transform.position, transform.rotation);
            _temp.GetComponent<Bullet>().damage = _playerInformation.damage;
            _temp = Instantiate(attackBullet, TwinBulletPosition2.transform.position, transform.rotation);
            _temp.GetComponent<Bullet>().damage = _playerInformation.damage;
        }
        else
        {
            _temp = Instantiate(attackBullet, bulletPosition.transform.position, transform.rotation);
            _temp.GetComponent<Bullet>().damage = _playerInformation.damage;
        }
    }
}
