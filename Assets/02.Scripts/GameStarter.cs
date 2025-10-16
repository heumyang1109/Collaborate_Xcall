using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private GameObject titleUI;  // Ÿ��Ʋ ȭ�� UI (TitleUI)
    [SerializeField] private GameObject gameUI;   // ���� ȭ�� UI
    [SerializeField] private Button startButton;  // TitleUI StartGame ��ư

    void Start()
    {
        // ���� �� Ÿ��Ʋ ȭ�鸸 ���̰�
        if (titleUI != null) titleUI.SetActive(true);
        if (gameUI != null) gameUI.SetActive(false);

        // ��ư Ŭ�� �̺�Ʈ ����
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }
    }

    // ���� ����
    public void StartGame()
    {
        if (titleUI != null) titleUI.SetActive(false);
        if (gameUI != null) gameUI.SetActive(true);
    }

    // Ÿ��Ʋ�� ���ư���
    public void BackToTitle()
    {
        if (titleUI != null) titleUI.SetActive(true);
        if (gameUI != null) gameUI.SetActive(false);
    }
}