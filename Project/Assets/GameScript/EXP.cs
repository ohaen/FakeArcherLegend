using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : MonoBehaviour
{
    private Transform _playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameManager.Instance.playerTransform;
        StartCoroutine(MoveExp());
    }


    IEnumerator MoveExp()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            while(GameManager.Instance.Mosnters.Count <= 0)
            {
                if (GetComponent<CapsuleCollider>().enabled)
                {
                    GetComponent<CapsuleCollider>().enabled = false;
                }
                
                transform.position = Vector3.Lerp(transform.position, _playerTransform.Find("Hip").transform.position, 0.1f);
                yield return null;
            }
        }
    }
}
