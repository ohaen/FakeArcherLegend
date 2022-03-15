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
            randomPos.y = 1.0f;
            GameObject temp = Instantiate(EXP, randomPos, transform.rotation);
            temp.transform.Rotate(10, Random.Range(0, 360), 0);
            temp.GetComponent<Rigidbody>().velocity += temp.transform.forward * Random.Range(0f, 2f);
        }
        Destroy(gameObject.transform.parent.gameObject);
        GameManager.Instance.Mosnters.Remove(gameObject);
    }

}
