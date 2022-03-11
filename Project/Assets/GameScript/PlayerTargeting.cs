using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargeting : MonoBehaviour
{
    public GameObject player;
    private PlayerMove _playerMove;
    private Animator _playerAnimator;
    private AutoFire _playerAutoFire;


    public List<GameObject> stageMonsterList;

    private RaycastHit hit;
    void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
        _playerAnimator = GetComponent<Animator>();
        _playerAutoFire = GetComponent<AutoFire>();
    }

    void Update()
    {
        if (GameManager.Instance.Mosnters.Count >= 1 && false == (_playerAnimator.GetBool("Run")))
        {
            //Debug.Log("·è¿§ µé¾î¿È");
            SetLookAt();
        }
        else
        {
            transform.LookAt(transform.position + _playerMove.MoveVec());
        }
    }

    private void SetLookAt()
    {
        float _aprochMonsterDistance = 100000f;
        bool _findMonster = false;

        for (int i = 0; i < GameManager.Instance.Mosnters.Count; ++i)
        {
            float distance = Vector3.Distance(player.transform.position, GameManager.Instance.Mosnters[i].transform.position);

            Physics.Raycast(player.transform.position, GameManager.Instance.Mosnters[i].transform.position - player.transform.position, out hit, distance);

            if (hit.collider.tag == "Monster")
            {
                Debug.DrawRay(player.transform.position,
                GameManager.Instance.Mosnters[i].transform.position - player.transform.position,
                Color.green);
                if (_aprochMonsterDistance > distance)
                {
                    _aprochMonsterDistance = distance;
                    transform.LookAt(GameManager.Instance.Mosnters[i].transform.position);
                }
                _findMonster = true;
            }

            if (_findMonster == false)
            {
                Debug.DrawRay(player.transform.position,
                GameManager.Instance.Mosnters[i].transform.position - player.transform.position,
                Color.red);
                if (_aprochMonsterDistance > distance)
                {
                    _aprochMonsterDistance = distance;
                    transform.LookAt(GameManager.Instance.Mosnters[i].transform.position);
                }
            }

            _playerAnimator.SetBool("Attack", true);
        }
    }

    
}
