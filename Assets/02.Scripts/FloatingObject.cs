using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    [Header("Float Settings")]
    [SerializeField] private float floatAmplitude = 0.5f; // 위아래 움직이는 범위
    [SerializeField] private float floatSpeed = 1f; // 떠다니는 속도
    [SerializeField] private bool randomOffset = true; // 각 오브젝트마다 다른 시작 타이밍

    private Vector3 startPosition;
    private float timeOffset;

    void Start()
    {
        startPosition = transform.position;

        // 랜덤 오프셋으로 각 오브젝트가 다른 타이밍에 움직이게
        if (randomOffset)
        {
            timeOffset = Random.Range(0f, 2f * Mathf.PI);
        }
    }

    void Update()
    {
        // 사인 함수로 부드러운 위아래 움직임
        float newY = startPosition.y + Mathf.Sin((Time.time * floatSpeed) + timeOffset) * floatAmplitude;

        transform.position = new Vector3(
            transform.position.x,
            newY,
            transform.position.z
        );
    }
}