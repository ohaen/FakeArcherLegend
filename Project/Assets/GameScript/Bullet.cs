using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BullBase
{

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, 5f);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            _rigidbody.velocity = Vector3.zero;
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Monster"))
        {
            _rigidbody.velocity = Vector3.zero;
            collision.gameObject.GetComponent<LivingEntity>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
