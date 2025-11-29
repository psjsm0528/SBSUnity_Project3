using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Player player;  // 외부에서 연결
    [SerializeField] private Enemy enemy;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.SetHP(100);
        player.SetAttackPower(10);

        enemy.SetHP(500);
        enemy.SetAttackPower(5);

        //player.Damage(enemy.GetAttackPower());   // 10 enemy의 공격력 만큼 데미지를 입게 해주세요
        //enemy.Damage(player.GetAttackPower());    // 10 player의 공격력 만큼 데미지를 입게 해보세요
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
