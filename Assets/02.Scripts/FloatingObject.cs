using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    [Header("Float Settings")]
    [SerializeField] private float floatAmplitude = 0.5f; // ���Ʒ� �����̴� ����
    [SerializeField] private float floatSpeed = 1f; // ���ٴϴ� �ӵ�
    [SerializeField] private bool randomOffset = true; // �� ������Ʈ���� �ٸ� ���� Ÿ�̹�

    private Vector3 startPosition;
    private float timeOffset;

    void Start()
    {
        startPosition = transform.position;

        // ���� ���������� �� ������Ʈ�� �ٸ� Ÿ�ֿ̹� �����̰�
        if (randomOffset)
        {
            timeOffset = Random.Range(0f, 2f * Mathf.PI);
        }
    }

    void Update()
    {
        // ���� �Լ��� �ε巯�� ���Ʒ� ������
        float newY = startPosition.y + Mathf.Sin((Time.time * floatSpeed) + timeOffset) * floatAmplitude;

        transform.position = new Vector3(
            transform.position.x,
            newY,
            transform.position.z
        );
    }
}