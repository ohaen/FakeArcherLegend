using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfomation : LivingEntity
{
    public Slider EXPBar;
    public Text _levelText;
    public bool doubleAttack;
    public bool twinAttack;
    public int damageUpCount;
    public int attackSpeedUpCount;
    public int moveSpeedUpCount;

    public float level;
    public float needEXP;
    public float currentEXP;

    void Start()
    {
        _levelText.text = ($"LV {level}");
        UpdateNeedEXP();
        UpdateCurrentEXP();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EXP"))
        {
            ++currentEXP;
            if (needEXP <= currentEXP)
            {
                LevelUp();
            }
            UpdateCurrentEXP();
            Destroy(other.transform.parent.gameObject);
        }
    }


    //// Update is called once per frame
    //void Update()
    //{

    //}

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
        base.Die();
    }
}
