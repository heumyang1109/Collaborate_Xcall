using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMap : MonoBehaviour
{
    [Header("이동 설정")]
    [SerializeField] float speed = 3f;
    [SerializeField] bool loop = true;
    [SerializeField] float offscreenMargin = 1f;

    [Header("루프 시작 위치(옵션")]
    [SerializeField] Transform resetPoint;

    float leftBoundX;
    Vector3 startPos;

    void Start()
    {
        startPos = resetPoint ? resetPoint.position : transform.position;
        RecalcleftBound();
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

        RecalcleftBound();
        if(transform.position.x <= leftBoundX)
        {
            if (loop)
            {
                var p = transform.position;
                p.x = startPos.x;
                transform.position = p;

            }
            else
            {
                Destroy(gameObject);
            }
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
            leftBoundX = cam.transform.position.x - halfWidth - offscreenMargin - 1f;
        }
        else
        {
            float halfHeight = 5f;
            float halfWidth = halfHeight * cam.aspect;
            leftBoundX = cam.transform.position.x - halfWidth - offscreenMargin - 1f;
        } 
    }
}
