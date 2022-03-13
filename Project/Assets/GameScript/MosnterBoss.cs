using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MosnterBoss : LivingEntity
{
    public enum EState
    {
        Idle,
        Move,
        Attack,
    }

    public EState currentState;

    public NavMeshAgent nvAgent;
    public GameObject hitBox;
    public GameObject throwObject;
    public Transform throwPosition;
    public Slider BossHPBar;

    private GameObject _targetPlayer;
    private Animator _animator;

    private Vector3 _targetVec;
    private float _distance;
    private float _lastAttackTime;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _targetPlayer = GameManager.Instance.playerTransform.gameObject;
        _lastAttackTime = Time.time;
        nvAgent = GetComponent<NavMeshAgent>();
        nvAgent.speed = moveSpeed;
        currentState = EState.Move;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    public override void Die()
    {
        GetComponent<NavMeshAgent>().speed = 0;
        _animator.SetBool("Die", true);
        Invoke("GameOverEvent", 1.5f);
        base.Die();
    }
    void GameOverEvent()
    {
        GameManager.Instance.EndGame();
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector3.Distance(gameObject.transform.position, _targetPlayer.transform.position);
        switch (currentState)
        {
            case EState.Move:
                {
                    _targetVec = _targetPlayer.transform.position;
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

        if (_canAttack)
        {
            _lastAttackTime = Time.time;
            _canAttack = false;
            //int attackNum = 1;
            int attackNum;
            if (_distance > 2.0f)
            {
                attackNum = 1;
            }
            else
            {
                attackNum = 0;
            }

            switch (attackNum)
            {
                case 0:
                    StartCoroutine(MeleeAttack());
                    break;

                case 1:
                    StartCoroutine(ThrowAttack());
                    break;
            }
        }

        if (_lastAttackTime + attackDelay < Time.time)
        {
            _canAttack = true;
        }

        BossHPBar.maxValue = maxHP;
        BossHPBar.value = currentHP;

    }

    IEnumerator MeleeAttack()
    {
        //bool whileloop = true;
        _canAttack = false;
        nvAgent.speed = 0f;
        _animator.SetBool("Attack", true);
        currentState = EState.Attack;
        transform.LookAt(_targetVec);
        yield return new WaitForSeconds(0.8f);
        hitBox.GetComponent<HitBox>().ActiveHitBox();
        yield return new WaitForSeconds(0.2f);
        hitBox.GetComponent<HitBox>().DisableHitBox();
        yield return new WaitForSeconds(1f);

        nvAgent.speed = moveSpeed;
        _lastAttackTime = Time.time;
        _animator.SetBool("Attack", false);
        currentState = EState.Move;
        yield return null;
    }

    IEnumerator ThrowAttack()
    {
        _canAttack = false;
        nvAgent.speed = 0f;
        _animator.SetBool("ThrowAttack", true);
        currentState = EState.Attack;
        transform.LookAt(_targetVec);
        yield return new WaitForSeconds(1.2f);
        GameObject temp = Instantiate(throwObject, throwPosition.position, gameObject.transform.rotation);
        temp.GetComponent<BossRock>().damage = damage;
        yield return new WaitForSeconds(1f);

        nvAgent.speed = moveSpeed;
        _lastAttackTime = Time.time;
        _animator.SetBool("ThrowAttack", false);
        currentState = EState.Move;
        yield return null;
    }

    public void SetActiveHitBox()
    {
        hitBox.GetComponent<HitBox>().ActiveHitBox();
        //hitBox.gameObject.SetActive(true);
    }
}
