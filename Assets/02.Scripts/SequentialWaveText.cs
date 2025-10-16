using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SequentialWaveText : MonoBehaviour
{
    [Header("Wave Settings")]
    [SerializeField] private Text textOne;          // ù ��° �ؽ�Ʈ
    [SerializeField] private Text textTwo;          // �� ��° �ؽ�Ʈ
    [SerializeField] private float animationDuration = 0.3f; // �� ���� �ִϸ��̼� �ð�
    [SerializeField] private float waveHeight = 10f;// ���Ʒ� �̵� ����
    [SerializeField] private float letterDelay = 0.1f; // ���� �� ���� ����
    [SerializeField] private float holdDelay = 0.5f;   // ������ ���� �� ��� �ð�

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

        // ���� �ؽ�Ʈ�� ����� �� ���ڸ� ���� Text�� ����
        targetText.enabled = false;

        List<Text> letterTexts = new List<Text>();
        RectTransform parentRect = targetText.GetComponent<RectTransform>();

        // ���� ���� ����� ���� �ӽ� ����
        float charWidth = targetText.fontSize * 0.6f; // �뷫���� ���� ��
        float startX = -(textLength * charWidth) / 2f; // �߾� ������ ���� ���� ��ġ

        // �� ���ڸ� ���� ������Ʈ�� ����
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

        // �� ������ ���� �ð� ����
        float[] letterStartTime = new float[textLength];
        for (int i = 0; i < textLength; i++)
        {
            letterStartTime[i] = i * letterDelay;
        }

        float totalDuration = letterStartTime[textLength - 1] + animationDuration;
        float elapsedTime = 0f;

        // �ִϸ��̼� ����
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

        // ������ ���� ������Ʈ ����
        foreach (Text letter in letterTexts)
        {
            Destroy(letter.gameObject);
        }

        // ���� �ؽ�Ʈ �ٽ� ǥ��
        targetText.enabled = true;

        yield return new WaitForSeconds(holdDelay);
    }
}