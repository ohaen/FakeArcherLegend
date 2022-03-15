using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kong : MonoBehaviour
{
    private Transform _playerTransform;
    private Vector3 _startPos;
    private Vector3 _targetVec;
    public float height = 5000.0f;
    public float ms;
    public float damage;
    private Vector3 center;
    private Vector3 middleCenter;

    void Start()
    {
        _playerTransform = GameManager.Instance.playerTransform;
        _startPos = this.transform.position;
        _targetVec = _playerTransform.position;
        //Destroy(gameObject, 1f);
        //center = (_startPos + _targetVec) / 3;
        //center = new Vector3(center.x, center.y + 5.0f, center.z);
        center = new Vector3(_targetVec.x, _targetVec.y + 5.0f, _targetVec.z);
        Destroy(gameObject, 3f);
        Debug.Log("»ý¼ºµÊ");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<LivingEntity>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ms += Time.deltaTime;

        //transform.position = Vector3.Lerp(transform.position, _targetVec, ms);
        if (ms < 1f)
        {
            transform.position = Vector3.Lerp(transform.position, center, ms / 50.0f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _targetVec, ms / 100.0f);
        }
    }


}
