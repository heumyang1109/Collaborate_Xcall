using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonHandler : MonoBehaviour
{
    [Header("Button Settings")]
    [SerializeField] private Button startButton;  // StartScene 버튼
    [SerializeField] private string sceneName = "SampleScene";  // 로드할 씬 이름

    void Start()
    {
        // 버튼 클릭 이벤트 연결
        if (startButton != null)
        {
            startButton.onClick.AddListener(LoadSampleScene);
        }
    }

    // SampleScene 로드
    public void LoadSampleScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}