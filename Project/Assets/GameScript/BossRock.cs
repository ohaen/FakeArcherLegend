using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRock : MonoBehaviour
{
    public float stoneSpeed;
    public float damage;
    void Start()
    {
        gameObject.transform.LookAt(GameManager.Instance.playerTransform.position);
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * stoneSpeed;
    }

    void Update()
    {
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<LivingEntity>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
