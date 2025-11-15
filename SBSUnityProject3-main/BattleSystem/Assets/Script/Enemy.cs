using UnityEngine;

public class Enemy : Entity
{
    protected override void Dead()
    {
        base.Dead();

        Debug.Log("Enemy 사망했습니다.");
    }
}
