using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private GameObject titleUI;  // 타이틀 화면 UI (TitleUI)
    [SerializeField] private GameObject gameUI;   // 게임 화면 UI
    [SerializeField] private Button startButton;  // TitleUI StartGame 버튼

    void Start()
    {
        // 시작 시 타이틀 화면만 보이게
        if (titleUI != null) titleUI.SetActive(true);
        if (gameUI != null) gameUI.SetActive(false);

        // 버튼 클릭 이벤트 연결
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }
    }

    // 게임 시작
    public void StartGame()
    {
        if (titleUI != null) titleUI.SetActive(false);
        if (gameUI != null) gameUI.SetActive(true);
    }

    // 타이틀로 돌아가기
    public void BackToTitle()
    {
        if (titleUI != null) titleUI.SetActive(true);
        if (gameUI != null) gameUI.SetActive(false);
    }
}