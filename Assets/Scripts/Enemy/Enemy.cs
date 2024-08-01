using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IDestroyable
{
    [SerializeField] public float MaxHP = 10f;
    [SerializeField] protected float HP = 10f;
    [SerializeField] public Transform SootPoint;
    [SerializeField] public Animator Animator;
    private bool _die = false;
    public Coroutine attackCoroutine;

    public State CurrentState;

    public State RestState;
    public State FollowPlayerState;
    public State AttackState;

    public State Rest { get; set; }
    public State FollowPlayer { get; set; }
    public State Attack { get; set; }

    public event Action<float> HPChange;
    public event Action EnemyDie;

    private void Start()
    {
        Init();   
    }

    private void FixedUpdate()
    {
        //if (!CurrentState.IsFinished)
        CurrentState.Run();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Player>().TakeDamage(2f);        
        }
    }

    public virtual void DestroyEvent()
    {
        _die = true;
        if (attackCoroutine != null) StopCoroutine(attackCoroutine);
        EnemySpawner.Instance.Enemys.Remove(transform.gameObject);
        Animator.SetTrigger("Die");   
        
        EnemyDie?.Invoke();
    }
    public void DieEnemy()
    {           
        Coin.CreateCoin(new Vector3(transform.position.x, 1.4f, transform.position.z));
        Destroy(transform.gameObject);
    }

    public virtual void TakeDamage(float damage)
    {
        if (_die) return;

        HP -= damage;
        if (HP <= 0)
        {
            DestroyEvent();
            HPChange?.Invoke(0f);
        }
        else
        {
            HPChange?.Invoke(HP / MaxHP);
        }
    }

    public void SetState(State state)
    {
        if (attackCoroutine != null) StopCoroutine(attackCoroutine);
        attackCoroutine = null;

        if (CurrentState != null) CurrentState.Active = false;
        CurrentState = state;
        if (state.IsLoop) enabled = true;
        else
        {
            enabled = false;
            OneShotRun();
        }
    }
    public virtual void Init()
    {
        HP = MaxHP;
        Rest = Instantiate(RestState);
        FollowPlayer = Instantiate(FollowPlayerState);
        Attack = Instantiate(AttackState);
        SetState(Rest);
        if (!EnemySpawner.Instance.Enemys.Contains(gameObject))
            EnemySpawner.Instance.Enemys.Add(gameObject);

        StatCanvasScript.Instance.CreateHpBar(this, transform, new Vector3(0f, 2.73f, 0.57f));
        //Animator.SetTrigger("Rest");
    }

    public void OneShotRun()
    {
        CurrentState.Run();
    }

}
