using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoxMonster : MonsterHealth
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
    public GameObject fireObject;
    public GameObject fireArea;

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
        _animator.SetBool("Move", true);
    }

    void Update()
    {
        _targetVec = GameManager.Instance.playerTransform.transform.position;
        nvAgent.SetDestination(_targetVec);
        switch (currentState)
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

        //nvAgent.SetDestination(_targetVec);
        float distance = Vector3.Distance(transform.position, GameManager.Instance.playerTransform.transform.position);

        if (_canAttack && distance < attackRange)
        {
            _canAttack = false;
            currentState = EState.Attack;
            StartCoroutine(Attack());
        }
        //if (distance < attackRange && _canAttack)
        //{
        //    _canAttack = false;
        //    currentState = EState.Attack;
        //    StartCoroutine(Attack());
        //}
    }
    private IEnumerator Attack()
    {
        nvAgent.speed = 0f;
        _animator.SetBool("Move", false);
        fireArea.gameObject.SetActive(true);
        fireArea.transform.position = GameManager.Instance.playerTransform.transform.position;
        GameObject temp = Instantiate(fireObject, gameObject.transform.position, gameObject.transform.rotation);
        temp.GetComponent<Kong>().damage = damage;
        yield return new WaitForSeconds(2.1f);


        _animator.SetBool("Move", true);
        fireArea.gameObject.SetActive(false);
        nvAgent.speed = moveSpeed;
        Destroy(temp);
        yield return new WaitForSeconds(3.0f);
        _canAttack = true;
    }
    //private IEnumerator Attack()
    //{
    //    _animator.SetBool("Attack", true);
    //    transform.LookAt(_targetVec);
    //    yield return new WaitForSeconds(attackDelay);
    //    lastAttackTime = Time.time;
    //    yield return new WaitForEndOfFrame();

    //    while (lastAttackTime + 0.1f > Time.time)
    //    {
    //        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 10f;
    //        //transform.position = Vector3.MoveTowards(transform.position, _targetVec, Time.deltaTime * 10f);
    //        yield return null;
    //    }
    //    gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    //    hitBox.gameObject.SetActive(true);
    //    //gameObject.transform.Find("HitBox").gameObject.SetActive(true);
    //    yield return new WaitForSeconds(0.1f);
    //    hitBox.gameObject.SetActive(false);
    //    //gameObject.transform.Find("HitBox").gameObject.SetActive(false);
    //    _animator.SetBool("Attack", false);
    //    yield return new WaitForSeconds(1f);
    //    _canAttack = true;
    //    currentState = EState.Move;

    //    yield return null;
    //}

}
