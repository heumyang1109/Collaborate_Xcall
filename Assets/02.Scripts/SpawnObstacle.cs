using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class SpawnObstacle : MonoBehaviour
{
    [Header("��ֹ� ������")]
    public GameObject[] obstaclePrefabs;

    private int stackCount = 12; // ��� ���� ����
    private float verticalGap = 0f; // ��ϻ��� ����
    private bool makeChild = true; // �������� �� ������Ʈ�� �ڽ����� ����
    private bool useColliderBounds = false; // �ݶ��̴� �������� ���� ��������

    private Vector3 startWorldPosition = new Vector3(10f,-4.85f,0f); // ��� �ױ� ���� ��ġ

    private Coroutine spawnRoutine;
    void Start()
    {
        spawnRoutine =  StartCoroutine(MakeObstacleCo());
    }
    IEnumerator MakeObstacleCo()
    {
        if (obstaclePrefabs == null)
        {
           yield return null;
        }
        startWorldPosition = new Vector3(10f, -4.85f, 0f);
        yield return new WaitForSeconds(1.0f);
        float currentTopY = startWorldPosition.y; // ���� ����� �ٴ��� ��

        int randIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedPrefab = obstaclePrefabs[randIndex];

        // ���� 3ĭ ��� ���� �ε��� ���� (1 ~ stackCount-2)
        
        int safeZone = (stackCount >= 2) ? Random.Range(1, stackCount - 2) : -1;

        for (int i = 0; i < stackCount; i++)
        {
            bool isSafe = (i == safeZone) || (i == safeZone + 1) || (i == safeZone + 2);

            GameObject go = Instantiate(selectedPrefab, Vector3.zero, Quaternion.identity); //�ӽ÷�(0,0,0)���� ���� -> bound�� ũ�� �������

            float height = GetWorldHeight(go); // �������� ���� ����󿡼��� ���� ���
            float half = height * 0.5f;

            Vector3 worldPos = startWorldPosition; // �̹� ����� ���� ��ġ ��� : �ٴ��� currentTopY�� �굵��
            startWorldPosition.y = currentTopY + half;

            if (isSafe)
            {
                // �� �ε����� ����� �ϹǷ�, �ӽ� ������ ������Ʈ�� �ٷ� ����
                Destroy(go);
            }
            else
            {
                // ���� ��ġ
                if (makeChild) go.transform.SetParent(transform, worldPositionStays: true);
                go.transform.position = worldPos; // �θ� �ڽ� ���� ������� ������ǥ�� ��Ȯ�� ��ġ
            }
            currentTopY += height + verticalGap; // ���� ����� ���� Top ������Ʈ
        }
    }

    //Prefab ��ü�� ���� ���� ���
    float GetWorldHeight(GameObject go)
    {
        if (useColliderBounds)
        {
            var cols = go.GetComponentsInChildren<Collider2D>(includeInactive: true);
            if (cols != null && cols.Length > 0)
            {
                Bounds b = cols[0].bounds;
                for (int i = 1; i < cols.Length; i++)
                {
                    b.Encapsulate(cols[i].bounds);
                }
                return Mathf.Max(0.0001f, b.size.y);
            }
        }
        var rends = go.GetComponentsInChildren<SpriteRenderer>(includeInactive: true);
        if (rends != null && rends.Length > 0)
        {
            Bounds b = rends[0].bounds;
            for (int i = 1; i < rends.Length; i++) b.Encapsulate(rends[i].bounds);
            return Mathf.Max(0.0001f, b.size.y);
        }
        //��������Ʈ�� �ݶ��̴��� ���ٸ� ������ 1�������� ���ǰ�
        return 1f;
    }

}
