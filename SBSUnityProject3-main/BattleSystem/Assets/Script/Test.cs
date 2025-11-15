using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.SetHP(500);
        player.SetAttackPower(10);

        enemy.SetHP(500);
        enemy.SetAttackPower(5);

        //player.Damage(enemy.GetAttackPower());
        //enemy.Damage(player.GetAttackPower());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
