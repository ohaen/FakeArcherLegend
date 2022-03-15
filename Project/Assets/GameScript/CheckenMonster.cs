using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckenMonster : MonsterHealth
{
    public enum EState
    {
        Idle,
        Move,
        Attack,
    }

    public EState currentState;

    public NavMeshAgent nvAgent;
    public int attackRange;
    public BoxCollider hitBox;

    private float lastAttackTime;
    private Animator _animator;

    private Vector3 _targetVec;

    void Start()
    {
        currentState = EState.Move;
        _targetVec = GameManager.Instance.playerTransform.transform.position;
        _animator = GetComponent<Animator>();
        nvAgent = GetComponent<NavMeshAgent>();
        nvAgent.speed = moveSpeed;
    }

    void Update()
    {
        switch(currentState)
        {
            case EState.Move:
                {
                    _targetVec = GameManager.Instance.playerTransform.transform.position;
                    break;
                }
            case EState.Attack:
                {
                    break;
                }
            default:
                {
                    break;
                }
        }

        nvAgent.SetDestination(_targetVec);
        float distance = Vector3.Distance(transform.position, GameManager.Instance.playerTransform.transform.position);
        
            
        if (distance < attackRange && _canAttack)
        {
            _canAttack = false;
            currentState = EState.Attack;
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        _animator.SetBool("Attack", true);
        transform.LookAt(_targetVec);
        yield return new WaitForSeconds(attackDelay);
        lastAttackTime = Time.time;
        yield return new WaitForEndOfFrame();

        while (lastAttackTime + 0.1f > Time.time)
        {
            gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 10f;
            //transform.position = Vector3.MoveTowards(transform.position, _targetVec, Time.deltaTime * 10f);
            yield return null;
        }
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        hitBox.gameObject.SetActive(true);
        //gameObject.transform.Find("HitBox").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        hitBox.gameObject.SetActive(false);
        //gameObject.transform.Find("HitBox").gameObject.SetActive(false);
        _animator.SetBool("Attack", false);
        yield return new WaitForSeconds(1f);
        _canAttack = true;
        currentState = EState.Move;

        yield return null;
    }
    
}
