using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    // 체력    - 
    // 공격력  -
    [SerializeField] TextMeshProUGUI attackText;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] Player player;
    [SerializeField] Image hpBar;

    // Update is called once per frame
    void Update()
    {
        attackText.text = $"공격력 : {player.GetAttackPower()}";
        hpText.text = $"체력 : {player.GetHP()} / {player.GetMaxHP()}";
        moneyText.text = $"돈 : {player.GetMoney()}";
        hpBar.fillAmount = (float)player.GetHP() / player.GetMaxHP();
    }
}
