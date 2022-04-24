using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : BullBase
{
    public int boundCount;
    private Rigidbody _rigidbody;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (boundCount > 0)
            {
                ReflectedObject(collision);
                --boundCount;
            }
            else
            {
                _rigidbody.velocity = Vector3.zero;
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Monster"))
        {
            OnCollisionMonster(collision);
        }
    }

    private void OnCollisionMonster(Collision collision)
    {
        _rigidbody.velocity = Vector3.zero;
        collision.gameObject.GetComponent<LivingEntity>().TakeDamage(damage);
        Destroy(gameObject);
    }

    private void ReflectedObject(Collision collision)
    {
        Vector3 incommingVec = transform.position - startPos;
        Vector3 reflectVec = Vector3.Reflect(incommingVec, collision.contacts[0].normal);
        startPos = transform.position;
        _rigidbody.velocity = reflectVec.normalized * speed;
        transform.forward = reflectVec.normalized;
    }
}
