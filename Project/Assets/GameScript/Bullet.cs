using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            _rigidbody.velocity = Vector3.zero;
            Destroy(gameObject, 1f);
        }
        else if (other.CompareTag("Monster"))
        {
            _rigidbody.velocity = Vector3.zero;
            other.GetComponent<LivingEntity>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
