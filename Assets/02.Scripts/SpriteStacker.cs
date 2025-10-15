using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteStacker : MonoBehaviour
{
    [Header("장애물 프리팹")]
    public GameObject[] obstaclePrefabs;

    private int stackCount = 12;
    private float verticalGap = 0f;
    private bool makeChild = true;
    private bool useColliderBounds = false;

    private Vector3 startWorldPosition = Vector3.zero;

    void Start()
    {
        if(obstaclePrefabs == null)
        {
            return;
        }
        float currentTopY = startWorldPosition.y;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
