using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundCreate : MonoBehaviour
{
    public Camera camera=null; //비우면 main카메라 사용
    [SerializeField] GameObject groundPrefab; // 생성할 블록 프리팹
    private int stackCount; //블록 개수
    private float sizeX; // 카메라 Width 폭

    float moveSpeed = 3f;         // 왼쪽(-X) 이동 속도
    public float extraMargin = 0f;      // 화면 밖 판정

    private Transform[,] groundArr = new Transform[1,2];
    //private readonly List<Transform> grounds = new List<Transform>();
    private float leftBoundX;

    private Vector3 groundPos;
    private Vector3 lastPos;
    private Vector3 nextPos;
    private Vector3 nextPos2;
    private int count = 0;

    private void Awake()
    {
        if (!camera) camera = Camera.main;
    }
    private void Start()
    {
        sizeX = 2f * camera.orthographicSize * Screen.width / Screen.height; 
        stackCount = (int)sizeX+2;
        groundArr = new Transform[2, stackCount];
        groundPos = new Vector3(-10.5f, -5f, 0f);
        Vector3 startPos = groundPos;
        Debug.Log(stackCount);
        for (int i = 0; i < stackCount; i++)
        {
            groundPos = new Vector3(groundPos.x + 1, groundPos.y, groundPos.z);
            groundArr[0,i] = CreateGround(groundPos);
            lastPos = groundPos;
            nextPos = groundPos;
        }
        for (int i = 0; i < stackCount; i++)
        {
            groundArr[1, i] = CreateGround(lastPos); 
            lastPos = new Vector3(lastPos.x + 1, lastPos.y, lastPos.z);
        }
    }
    private void Update()
    {
        nextPos2 = nextPos;
        if (groundArr == null) return;
        Vector3 move = Vector3.left * moveSpeed * Time.deltaTime;
        foreach(Transform t in groundArr)
        {
            t.transform.Translate(move, Space.World);
        }
        Debug.Log(groundArr[0, stackCount - 1].transform.position.x);

        if (groundArr[0, stackCount - 1].transform.position.x < -10f)
        {
            for (int i = 0; i < stackCount; i++)
            {
                groundArr[0, i].gameObject.SetActive(false);
                //groundArr[0, i].transform.position.x = nextPos.x + 1;
            }
            
            nextPos = nextPos2;

        }
    }

    Transform CreateGround(Vector3 pos)
    {
        return Instantiate(groundPrefab, pos, Quaternion.identity).transform;
    }



}
