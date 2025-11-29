using UnityEngine;

public class Enemy : Entity
{
    public int RewardMoney = 10;
    [SerializeField] Player player;

    private void Start()
    {
        player = Object.FindFirstObjectByType<Player>();  
    }

    protected override void Dead()
    {
        Debug.Log("Enemy 사망했습니다.");

        base.Dead();

        // 플레이어에게 RewardMoney 돈을 줘야한다.
        // Player가 누구인가?
        player.SetMoney(player.GetMoney() + RewardMoney);
    }



}
