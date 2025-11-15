using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 어떤 오브젝트를 생성할 것인가? Prefab
    // 몇 마리 생성할 것인가?
    // 몇 초 간격으로?
    [SerializeField] GameObject[] prefab;
    [SerializeField] int count = 5;
    [SerializeField] float interval = 1f;
    // 어디에서 생성할 것인가?
    [SerializeField] Transform spawnPos;
    private void Start()
    {
        StartCoroutine(SpawnInterval());
    }

    private void Spawn()
    {
        int index = UnityEngine.Random.Range(0, prefab.Length); // 동일한 확률
        Instantiate(prefab[index], spawnPos.position, Quaternion.identity);
    }

    IEnumerator SpawnInterval()
    {
        for (int i=0; i < count; i++) 
        {
            Spawn();
            yield return new WaitForSeconds(interval);
        }
        
    }
}
