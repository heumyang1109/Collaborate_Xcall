using System.Collections;
using UnityEngine;

public class RepeatSpawnObstacle : MonoBehaviour
{
    [Header("SpawnObstacle�� �پ��ִ� ������")]
    public GameObject spawnObstaclePrefab;

    [Header("���� �ֱ�/��ġ")]
    public float interval = 2f;          // 2�ʸ���
    public Transform spawnPoint;         // ���� �� ������Ʈ ��ġ���� ����

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
