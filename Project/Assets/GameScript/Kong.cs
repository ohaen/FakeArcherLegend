using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kong : MonoBehaviour
{
    private Transform _playerTransform;
    public float damage;

    public float h = 5;
    public float gravity = -18;

    void Start()
    {
        _playerTransform = GameManager.Instance.playerTransform;
        Launch();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<LivingEntity>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (gameObject.transform.position.y < -0.5f)
        {
            Destroy(gameObject);
        }
    }

    void Launch()
    {
        Physics.gravity = Vector3.up * gravity;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().velocity = CalculateLaunchVelocity();
    }

    Vector3 CalculateLaunchVelocity()
    {
        float displacementY = _playerTransform.position.y - gameObject.transform.position.y;
        Vector3 displacementXZ = new Vector3(_playerTransform.position.x - gameObject.transform.position.x, 0, _playerTransform.position.z - gameObject.transform.position.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity));

        return velocityXZ + velocityY;
    }

}
