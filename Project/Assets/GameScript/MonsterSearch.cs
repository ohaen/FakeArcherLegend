using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSearch : MonoBehaviour
{
    public GameObject _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어 충돌");
        }
        if (other.CompareTag("Monster"))
        {
            GameManager.Instance.Mosnters.Add(other.gameObject);
            Debug.Log("몬스터 충돌");
        }
    }
}
