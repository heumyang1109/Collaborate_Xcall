using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonHandler : MonoBehaviour
{
    [Header("Button Settings")]
    [SerializeField] private Button startButton;  // StartScene ��ư
    [SerializeField] private string sceneName = "SampleScene";  // �ε��� �� �̸�

    void Start()
    {
        // ��ư Ŭ�� �̺�Ʈ ����
        if (startButton != null)
        {
            startButton.onClick.AddListener(LoadSampleScene);
        }
    }

    // SampleScene �ε�
    public void LoadSampleScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}