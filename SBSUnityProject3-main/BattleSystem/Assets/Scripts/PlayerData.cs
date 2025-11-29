using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string Name;
    public int MONEY;
    public int ATK;
    public int HP;

    public PlayerData(string name, int money, int atk, int hp)
    {
        Name = name;
        MONEY = money;
        ATK = atk;
        HP = hp;
    }
}
