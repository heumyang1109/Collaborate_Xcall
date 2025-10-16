using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    [Header("Blink Settings")]
    [SerializeField] private float blinkSpeed = 1f; // 깜빡이는 속도

    private Text text;
    private float timer;

    void Start()
    {
        // Text 컴포넌트 가져오기
        text = GetComponent<Text>();

    }

    void Update()
    {
        timer += Time.deltaTime * blinkSpeed;

        // 부드러운 깜빡임 효과
        float alpha = (Mathf.Sin(timer) + 1.5f) / 2f; // 0~1 사이 값

        if (text != null)
        {
            Color color = text.color;
            color.a = alpha;
            text.color = color;
        }

    }
}