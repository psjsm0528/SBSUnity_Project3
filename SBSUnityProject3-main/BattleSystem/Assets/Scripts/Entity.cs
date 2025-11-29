using UnityEngine;

public class Entity : MonoBehaviour
{
    // 정수 형식으로 HealthPoint  AttackPower
    // 접근 지정자 private, public, protected 하나를 선택해서 선언을 하세요.
    // private   : Enemy class 개인적인 것. 다른 클래스에서 사용을 못하게해주세요. 
    // public    : 다른 클래스에서 모두 사용을 할 수 있습니다.
    // protected : 자식은 사용할 수 있게 해주세요

    // AttackPower 외부에서 수정할 수 있게끔 변경해보세요.
    // AttackPower 외부에서 사용할 수 있게 만들어야합니다.

    [SerializeField] private int HealthPoint;
    [SerializeField] private int MaxHealthPoint;
    [SerializeField] private int AttackPower; // Enemy가 player의 공격력을 직접적으로 변경할 수 있게 되버립니다.
    [SerializeField] Animator animator;

    bool IsDeath;
    public bool IsEnemy;

    public bool CheckDeath() => IsDeath;
    public int GetHP() => HealthPoint; 
    public int GetMaxHP() => MaxHealthPoint;
    public int GetAttackPower() => AttackPower;
    public void SetHP(int value) => HealthPoint = value;
    public void SetMaxHP(int value) => MaxHealthPoint = value;
    public void SetAttackPower(int value) => AttackPower = value;

    private void Start()
    {
        IsDeath = false;       
        HealthPoint = MaxHealthPoint;
    }


    public void Damage(Entity attacker)
    {
        if (IsDeath) { return; } // 죽었으면 아래 코드 실행하지마세요!

        // 공격자의 공격력으로부터 자신의 체력을 감소시킨다.
        int attackerPower = attacker.GetAttackPower();

        HealthPoint = HealthPoint - attackerPower;
        animator.SetTrigger("Hit");

        if(attacker.TryGetComponent<Move>(out var enemyMove)) // 공격 대상자가 Move.cs가 있을때만 실행하라
        {
            enemyMove.Stop();
            enemyMove.KnockBack();
        }


        if(HealthPoint <= 0)
        {
            Dead();
        }
    }

    protected virtual void Dead()
    {
        IsDeath = true;
        animator.SetTrigger("Death");

        //Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Entity>(out var entity)) // 충돌한 대상이. Entity 있으면 실행하라
        {
            // 시체랑은 충돌을 안하게 해주세요
            // 내가 Enemy일 때 다른 Enemy랑은 충돌안하게 해주세요.

            if(IsEnemy && entity.IsEnemy)
            {
                return;
            }

            if (entity.CheckDeath() == false)
            {
                Damage(entity);
            }           
        }
    }
}
