using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    [Header("Blink Settings")]
    [SerializeField] private float blinkSpeed = 1f; // �����̴� �ӵ�

    private Text text;
    private float timer;

    void Start()
    {
        // Text ������Ʈ ��������
        text = GetComponent<Text>();

    }

    void Update()
    {
        timer += Time.deltaTime * blinkSpeed;

        // �ε巯�� ������ ȿ��
        float alpha = (Mathf.Sin(timer) + 1.5f) / 2f; // 0~1 ���� ��

        if (text != null)
        {
            Color color = text.color;
            color.a = alpha;
            text.color = color;
        }

    }
}