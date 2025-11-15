using UnityEngine;

public class Player : Entity
{
    protected override void Dead()
    {
        base.Dead();

        Debug.Log("Player가 사망했습니다.");
    }
}
