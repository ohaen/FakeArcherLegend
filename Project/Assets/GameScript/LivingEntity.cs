using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, HealthBase
{
    public float maxHP;
    public float currentHP;
    public float damage;
    public float moveSpeed;
    public float attackSpeed;
    public float attackDelay;
    protected bool _canAttack = true;


    public virtual void TakeDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log("╬саж╠щ");
    }
}