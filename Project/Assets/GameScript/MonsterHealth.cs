using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : LivingEntity
{
    public GameObject EXP;
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();
        for (int i = 0; i < 5; ++i)
        {
            Vector3 randomPos = transform.position;
            randomPos.x += Random.Range(-1f, 1f);
            //randomPos.y += Random.Range(-1, 1);
            randomPos.z += Random.Range(-1f, 1f);
            Instantiate(EXP, randomPos, transform.rotation);
        }
        Destroy(gameObject.transform.parent.gameObject);
        GameManager.Instance.Mosnters.Remove(gameObject);
    }

}
