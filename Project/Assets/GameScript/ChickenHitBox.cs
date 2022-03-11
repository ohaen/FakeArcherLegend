using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenHitBox : MonoBehaviour
{
    private GameObject _parentObject;

    private void Start()
    {
        _parentObject = transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<LivingEntity>().TakeDamage(_parentObject.GetComponent<LivingEntity>().damage);
        }
    }
}
