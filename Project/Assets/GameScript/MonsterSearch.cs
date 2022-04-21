using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSearch : MonoBehaviour
{
    public GameObject _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            GameManager.Instance.Mosnters.Add(other.gameObject);
        }
    }
}
