using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMap : MonoBehaviour
{
    [Header("이동 설정")]
    [SerializeField] float speed = 3f;
    [SerializeField] float offscreenMargin = 1f;

    float leftBoundX;
    Vector3 startPos;

    void Start()
    {
        RecalcleftBound();
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

        RecalcleftBound();
        if(transform.position.x <= leftBoundX)
        {
                Destroy(gameObject);
        }
    }

    void RecalcleftBound()
    {
        var cam = Camera.main;
        if (!cam) return;

        if (cam.orthographic)
        {
            float halfHeight = cam.orthographicSize;
            float halfWidth = halfHeight * cam.aspect;
            leftBoundX = cam.transform.position.x - halfWidth - offscreenMargin - 7f;
            
        }
        else
        {
            float halfHeight = 5f;
            float halfWidth = halfHeight * cam.aspect;
            leftBoundX = cam.transform.position.x - halfWidth - offscreenMargin - 7f;
            
        } 
    }
}
