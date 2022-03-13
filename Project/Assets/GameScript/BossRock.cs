using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRock : MonoBehaviour
{
    //public Vector3 targetPos;
    public float stoneSpeed;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.LookAt(GameManager.Instance.playerTransform.position);
        //targetPos = GameManager.Instance.playerTransform.position;
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * stoneSpeed;
        //StartCoroutine(Throw());
    }

    // Update is called once per frame
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
