using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Entity : MonoBehaviour
{
    // 정수 형식으로 HealthPoint AttackPower
    // 접근 지정자 private, public, protected 하나를 선택해서 선언을 하세요.
    //접근
    [SerializeField] private int HealthPoint;
    [SerializeField] private int AttackPower; // Enemy가 player의 공격력을 직접적으로 변경할 수 있게 되버립니다.
    [SerializeField] Animator animator;

    bool IsDeath;
    public bool IsEnemy;

    public int GetHP() => HealthPoint;
    public void SetHP(int value) => HealthPoint = value;
    public int GetAttackPower() => AttackPower;
    public void SetAttackPower(int value) => AttackPower = value;

    private void Start()
    {
        IsDeath = false;
    }

    public void Damage(Entity attacker)
    {
        if (IsDeath) { return; }

        // 공격자의 공격력으로 부터 자신의 체력을 감소시킨다.
        int attacPkerower = attacker.GetAttackPower();

        HealthPoint = HealthPoint - attacPkerower;
        animator.SetTrigger("Hit");

        if (attacker.TryGetComponent<Move>(out var enemyMove))
        {
            enemyMove.Stop();
            enemyMove.KnockBack();
        }

        if (HealthPoint <= 0)
        {
            Dead();
        }
    }

    protected virtual void Dead()
    {
        IsDeath = true;
        animator.SetTrigger("Death");
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Entity>(out var entity)) // 충돌한 대상이 Entity 있으면 실행하라
        {
            //시체랑은 충돌을 안하게 해주세요
            // 내가 Enemy일 때 다른 Enemy랑은 충돌안하게 해주세요.

            if (IsEnemy && entity.IsEnemy)
            {
                 return;
            }

            if (entity.CheckDeath() == false)
            {
                Damage(entity);
            }
        }
    }

    private bool CheckDeath()
    {
        return IsDeath;
    }
}
