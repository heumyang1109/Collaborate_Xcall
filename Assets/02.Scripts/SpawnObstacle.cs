using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class SpawnObstacle : MonoBehaviour
{
    [Header("장애물 프리팹")]
    public GameObject[] obstaclePrefabs;

    private int stackCount = 12; // 블록 생성 개수
    private float verticalGap = 0f; // 블록사이 간격
    private bool makeChild = true; // 생성물을 이 오브젝트의 자식으로 둘지
    private bool useColliderBounds = false; // 콜라이더 기준으로 높이 측정할지

    private Vector3 startWorldPosition = new Vector3(10f,-4.85f,0f); // 블록 쌓기 시작 위치

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
        float currentTopY = startWorldPosition.y; // 다음 블록의 바닥의 값

        int randIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedPrefab = obstaclePrefabs[randIndex];

        // 연속 3칸 비울 시작 인덱스 선택 (1 ~ stackCount-2)
        
        int safeZone = (stackCount >= 2) ? Random.Range(1, stackCount - 2) : -1;

        for (int i = 0; i < stackCount; i++)
        {
            bool isSafe = (i == safeZone) || (i == safeZone + 1) || (i == safeZone + 2);

            GameObject go = Instantiate(selectedPrefab, Vector3.zero, Quaternion.identity); //임시로(0,0,0)으로 생성 -> bound의 크기 얻기위해

            float height = GetWorldHeight(go); // 프리팹의 실제 월드상에서의 높이 계산
            float half = height * 0.5f;

            Vector3 worldPos = startWorldPosition; // 이번 블록의 월드 위치 계산 : 바닥이 currentTopY에 닿도록
            startWorldPosition.y = currentTopY + half;

            if (isSafe)
            {
                // 이 인덱스는 비워야 하므로, 임시 생성한 오브젝트는 바로 제거
                Destroy(go);
            }
            else
            {
                // 실제 배치
                if (makeChild) go.transform.SetParent(transform, worldPositionStays: true);
                go.transform.position = worldPos; // 부모 자식 관계 상관없이 월드좌표로 정확히 배치
            }
            currentTopY += height + verticalGap; // 다음 블록을 위한 Top 업데이트
        }
    }

    //Prefab 전체의 월드 높이 계산
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
        //스프라이트랑 콜라이더가 없다면 스케일 1기준으로 임의값
        return 1f;
    }

}
