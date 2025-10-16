using System.Collections;
using UnityEngine;

public class RepeatSpawnObstacle : MonoBehaviour
{
    [Header("SpawnObstacle가 붙어있는 프리팹")]
    public GameObject spawnObstaclePrefab;

    [Header("생성 주기/위치")]
    public float interval = 2f;          // 2초마다
    public Transform spawnPoint;         // 비우면 이 오브젝트 위치에서 생성

    private Coroutine loop;

    void OnEnable()
    {
        if (spawnObstaclePrefab != null)
            loop = StartCoroutine(SpawnLoop());
    }

    void OnDisable()
    {
        if (loop != null) StopCoroutine(loop);
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            Vector3 pos = spawnPoint ? spawnPoint.position : transform.position;
            Instantiate(spawnObstaclePrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }
}
