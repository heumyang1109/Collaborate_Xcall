using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCreate : MonoBehaviour
{
    public Camera camera = null;                  // 비우면 main카메라 사용
    [SerializeField] GameObject groundPrefab;     // 생성할 블록 프리팹
    private int stackCount;                       // 블록 개수
    private float sizeX;                          // 카메라 Width 폭

    [SerializeField] float moveSpeed = 3f;        // 왼쪽(-X) 이동 속도
    [SerializeField] float leftThreshold = -10f;  // 화면 밖 판정 X (원하면 카메라 기준으로 갱신 가능)
    [SerializeField] float tileW = 1f;            // 타일 간격(초기 1, Start에서 자동 추정)

    private Transform[,] groundArr = new Transform[1, 2];
    private Transform[] groundsCol = new Transform[2];

    private Vector3 groundPos;
    private Vector3 lastPos;

    void Awake()
    {
        if (!camera) camera = Camera.main;
    }

    void Start()
    {
        sizeX = 2f * camera.orthographicSize * Screen.width / Screen.height;
        stackCount = (int)sizeX + 2;
        groundArr = new Transform[2, stackCount];

        groundPos = new Vector3(-10.5f, -5f, 0f);

        // ★ 행 루트 생성(하이어라키 정리)
        groundsCol[0] = new GameObject("Ground01").transform;
        groundsCol[1] = new GameObject("Ground02").transform;
        groundsCol[0].SetParent(transform, true);
        groundsCol[1].SetParent(transform, true);

        // 0번 행 생성
        for (int i = 0; i < stackCount; i++)
        {
            groundPos = new Vector3(groundPos.x + 1, groundPos.y, groundPos.z);
            groundArr[0, i] = CreateGround(groundPos, groundsCol[0]);
            lastPos = groundPos;
        }

        // 1번 행 생성(오른쪽에 이어 붙이기)
        for (int i = 0; i < stackCount; i++)
        {
            groundArr[1, i] = CreateGround(lastPos, groundsCol[1]);
            lastPos = new Vector3(lastPos.x + 1, lastPos.y, lastPos.z);
        }

        // ★ 타일 간격 자동 추정(현재 생성 규칙상 1이지만 안전하게 계산)
        if (stackCount > 1 && groundArr[0, 1] && groundArr[0, 0])
            tileW = Mathf.Abs(groundArr[0, 1].position.x - groundArr[0, 0].position.x);
    }

    void Update()
    {
        // ★ 타일 개별 이동 → 제거, 루트만 이동
        Vector3 move = Vector3.left * moveSpeed * Time.deltaTime;
        groundsCol[0].position += move;
        groundsCol[1].position += move;

        // ★ 각 행의 마지막 타일이 leftThreshold를 넘으면 반대 행 뒤로 래핑
        WrapIfOut(0, 1);
        WrapIfOut(1, 0);
    }

    // ---- 래핑 유틸 ----
    void WrapIfOut(int row, int otherRow)
    {
        Transform last = groundArr[row, stackCount - 1];
        Transform first = groundArr[row, 0];
        if (!last || !first) return;

        float lastRight = last.position.x + tileW * 0.5f; // 이 행 마지막 타일의 오른쪽 끝
        if (lastRight >= leftThreshold) return;            // 아직 화면을 완전히 벗어나지 않음

        Transform otherLast = groundArr[otherRow, stackCount - 1];
        if (!otherLast) return;
        float otherRight = otherLast.position.x + tileW * 0.5f; // 반대 행의 오른쪽 끝

        // 이 행의 첫 타일 중심을 "(반대 행 오른쪽 끝) + 한 칸"에 맞추도록 루트를 통째로 이동
        float targetFirstX = otherRight + tileW * 0.5f;
        float shift = targetFirstX - first.position.x;
        groundsCol[row].position += new Vector3(shift, 0f, 0f);
    }

    Transform CreateGround(Vector3 pos, Transform parent)
    {
        var t = Instantiate(groundPrefab, pos, Quaternion.identity).transform;
        t.SetParent(parent, true);
        return t;
    }
}
