using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfomation : LivingEntity
{
    private Animator _playerAnimator;
    public Slider EXPBar;
    public Text _levelText;
    public bool doubleAttack;
    public bool twinAttack;
    public bool sideAttack;
    public int damageUpCount;
    public int attackSpeedUpCount;
    public int moveSpeedUpCount;
    public int selectWeapon;

    public float level;
    public float needEXP;
    public float currentEXP;

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _levelText.text = ($"LV {level}");
        UpdateNeedEXP();
        UpdateCurrentEXP();
    }


    public void TakeEXP(float EXP)
    {
        ++currentEXP;
        if (needEXP <= currentEXP)
        {
            LevelUp();
        }
        UpdateCurrentEXP();
    }
    //// Update is called once per frame


    void LevelUp()
    {
        ++level;
        _levelText.text = ($"LV {level}");
        currentEXP -= needEXP;
        needEXP *= 1.3f;
        GameManager.Instance.slotmachin.gameObject.SetActive(true);
        UpdateNeedEXP();
    }

    void UpdateNeedEXP()
    {
        EXPBar.maxValue = needEXP;
    }
    void UpdateCurrentEXP()
    {
        EXPBar.value = currentEXP;
    }
    public void MaxHpUp()
    {
        maxHP *= 1.3f;
        currentHP = maxHP;
    }
    public float CalcDamage()
    {
        return damage + ((damage * 0.1f) * damageUpCount);
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        GetComponent<PlayerTargeting>().enabled = false;
        GetComponent<PlayerInput>().enabled = false;
        _playerAnimator.SetBool("Attack", false);
        _playerAnimator.SetBool("Die", true);
        Invoke("GameOverEvent", 1.5f);
        base.Die();
    }
    void GameOverEvent()
    {
        GameManager.Instance.EndGame();
    }
}
