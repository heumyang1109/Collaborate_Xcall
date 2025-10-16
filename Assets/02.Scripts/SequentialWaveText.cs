using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SequentialWaveText : MonoBehaviour
{
    [Header("Wave Settings")]
    [SerializeField] private Text textOne;          // 첫 번째 텍스트
    [SerializeField] private Text textTwo;          // 두 번째 텍스트
    [SerializeField] private float animationDuration = 0.3f; // 각 글자 애니메이션 시간
    [SerializeField] private float waveHeight = 10f;// 위아래 이동 높이
    [SerializeField] private float letterDelay = 0.1f; // 글자 간 시작 간격
    [SerializeField] private float holdDelay = 0.5f;   // 마지막 글자 후 대기 시간

    private bool isRunning = false;

    void Start()
    {
        StartCoroutine(PlaySequentialWave());
    }

    private IEnumerator PlaySequentialWave()
    {
        isRunning = true;

        if (textOne != null)
            yield return StartCoroutine(AnimateText(textOne));

        if (textTwo != null)
            yield return StartCoroutine(AnimateText(textTwo));

        isRunning = false;
    }

    private IEnumerator AnimateText(Text targetText)
    {
        string originalText = targetText.text;
        int textLength = originalText.Length;

        // 원본 텍스트를 숨기고 각 글자를 개별 Text로 생성
        targetText.enabled = false;

        List<Text> letterTexts = new List<Text>();
        RectTransform parentRect = targetText.GetComponent<RectTransform>();

        // 글자 간격 계산을 위한 임시 측정
        float charWidth = targetText.fontSize * 0.6f; // 대략적인 글자 폭
        float startX = -(textLength * charWidth) / 2f; // 중앙 정렬을 위한 시작 위치

        // 각 글자를 개별 오브젝트로 생성
        for (int i = 0; i < textLength; i++)
        {
            GameObject letterObj = new GameObject($"Letter_{i}");
            letterObj.transform.SetParent(targetText.transform, false);

            Text letterText = letterObj.AddComponent<Text>();
            letterText.text = originalText[i].ToString();
            letterText.font = targetText.font;
            letterText.fontSize = targetText.fontSize;
            letterText.color = targetText.color;
            letterText.alignment = TextAnchor.MiddleCenter;
            letterText.horizontalOverflow = HorizontalWrapMode.Overflow;
            letterText.verticalOverflow = VerticalWrapMode.Overflow;

            RectTransform letterRect = letterObj.GetComponent<RectTransform>();
            letterRect.sizeDelta = new Vector2(charWidth, targetText.fontSize);
            letterRect.anchoredPosition = new Vector2(startX + (i * charWidth), 0);

            letterTexts.Add(letterText);
        }

        // 각 글자의 시작 시간 설정
        float[] letterStartTime = new float[textLength];
        for (int i = 0; i < textLength; i++)
        {
            letterStartTime[i] = i * letterDelay;
        }

        float totalDuration = letterStartTime[textLength - 1] + animationDuration;
        float elapsedTime = 0f;

        // 애니메이션 실행
        while (elapsedTime < totalDuration)
        {
            elapsedTime += Time.deltaTime;

            for (int i = 0; i < textLength; i++)
            {
                float timeSinceStart = elapsedTime - letterStartTime[i];
                float progress = Mathf.Clamp01(timeSinceStart / animationDuration);
                float offsetY = Mathf.Sin(progress * Mathf.PI) * waveHeight;

                RectTransform letterRect = letterTexts[i].GetComponent<RectTransform>();
                letterRect.anchoredPosition = new Vector2(startX + (i * charWidth), offsetY);
            }

            yield return null;
        }

        // 생성한 글자 오브젝트 삭제
        foreach (Text letter in letterTexts)
        {
            Destroy(letter.gameObject);
        }

        // 원본 텍스트 다시 표시
        targetText.enabled = true;

        yield return new WaitForSeconds(holdDelay);
    }
}