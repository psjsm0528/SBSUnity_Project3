using UnityEngine;


public class SaveSystem : MonoBehaviour
{
    public PlayerData data;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("저장 시스템 예제 구현!");

        // alt + shift (위, 아래) 다중 커서 만들기
        // ctrl K ctrl c    ctrl k u 범위 주석 설정 ,해제
        
       
        //JsonUtility.ToJson()// JSON으로 만들겠다.

        Debug.Log("HP : " + PlayerPrefs.GetInt("HP"));
        Debug.Log("ATK : " + PlayerPrefs.GetFloat("ATK"));
        Debug.Log("NAME : " + PlayerPrefs.GetString("NAME"));
        Debug.Log("MONEY : " + PlayerPrefs.GetInt("MONEY"));

        Debug.Log(Application.persistentDataPath);  

      string json = JsonUtility.ToJson(data);
        Debug.Log(json);


    }

    public static void Save(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("PLAYER", json);
    }

    public static PlayerData Load()
    {
        string json = PlayerPrefs.GetString("PLAYER");
        return JsonUtility.FromJson<PlayerData>(json);
    }

}
