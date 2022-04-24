using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargeting : MonoBehaviour
{
    private PlayerMove _playerMove;
    private Animator _playerAnimator;
    private AutoFire _playerAutoFire;

    private Collider[] _monsters = new Collider[15];

    public int sphereRadiusForSight = 100;
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
            Debug.Log("타게팅 들어옴");
            SetLookAt();
        }
        else
        {
            transform.LookAt(transform.position + _playerMove.MoveVec());
        }
    }

    //private readonly int _monsterLayerMask = (1 << LayerMask.NameToLayer("Monster"));
    //private readonly int _wallLayerMask = (1 << LayerMask.NameToLayer("Wall"));
    private void SetLookAt()
    {
        int _monsterLayerMask = (1 << LayerMask.NameToLayer("Monster"));        //tem
        int _wallLayerMask = (1 << LayerMask.NameToLayer("Wall"));              //tem
        Transform target = null;
        float nearestDistance = 100000f;
        bool isTargetBehindWall = false;

        int collapsedMonsterCount = Physics.OverlapSphereNonAlloc(transform.position,
            sphereRadiusForSight, _monsters, _monsterLayerMask);
        for (int i = 0; i < collapsedMonsterCount; ++i)
        {
            Vector3 distanceVector = _monsters[i].transform.position - transform.position;
            float sqrDistance = distanceVector.sqrMagnitude;
            bool isBehindWall = Physics.Raycast(transform.position, distanceVector, sqrDistance, _wallLayerMask);
            Debug.DrawRay(transform.position, distanceVector, Color.red);
            if (target == null)
            {
                target = _monsters[i].transform;
                nearestDistance = sqrDistance;
                isTargetBehindWall = isBehindWall;

                continue;
            }
            if (nearestDistance <= sqrDistance)
            {
                if (isTargetBehindWall)
                {
                    target = _monsters[i].transform;
                    nearestDistance = sqrDistance;
                    isTargetBehindWall = isBehindWall;
                }
                continue;
            }
            if (isBehindWall)
            {
                continue;
            }
            target = _monsters[i].transform;
            nearestDistance = sqrDistance;
            isTargetBehindWall = isBehindWall;
        }
        transform.LookAt(target);


        //}
        //foreach (var monster in _monsters)
        //{
        //    float distance = Vector3.Distance(transform.position, monster.transform.position);
        //    Physics.Raycast(transform.position, monster.transform.position - transform.position, out hit, distance);
        //    if (hit.collider.tag == "Monster")
        //    {
        //        nearMonster = CalculateNearMonster(monster, ref _nearstMonsterDistance, distance);
        //    }
        //    else
        //    {
        //        invisibleNearMonster = CalculateNearMonster(monster, ref _invisibleNearstMonsterDistance, distance);
        //    }
        //}


        //if (nearMonster != null)
        //{
        //    transform.LookAt(nearMonster.transform.position);
        //}
        //else if (invisibleNearMonster != null)
        //{
        //    transform.LookAt(invisibleNearMonster.transform.position);
        //}

        _playerAnimator.SetBool("Attack", true);
    }

    GameObject CalculateNearMonster(Collider targetMonster, ref float nearstMonsterDistance, float distance)
    {
        Debug.DrawRay(transform.position,
        targetMonster.transform.position - transform.position,
        Color.red);

        if (nearstMonsterDistance > distance)
        {
            nearstMonsterDistance = distance;

            return targetMonster.gameObject;
        }
        else
        {
            return null;
        }
    }
}
