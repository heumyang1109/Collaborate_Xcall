using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text gameOverText;  // GameObject에서 Text로 변경
    [SerializeField] private Text currnetTimeText;
    [SerializeField] private Text countDown;
    [SerializeField] public Text passingPoint;
    [SerializeField] private string SceneName = " WriteScene Name ";

    private bool isGameOver;
    public bool isGameStart { get; private set; }
    private float currentTime;
    public float point;

    private void Start()
    {
        isGameOver = false;
        currentTime = 0f;
        Time.timeScale = 0;
        gameOverText.gameObject.SetActive(false);  // 시작 시 비활성화
        StartCoroutine(CountDown());
    }

    private void Update()
    {
        if (isGameOver)
        {
            gameOverText.gameObject.SetActive(true);  // .gameObject 추가
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneName);
            }
        }
        currentTime += Time.deltaTime;
        currnetTimeText.text = "" + (int)currentTime;
        passingPoint.text = "Score " + (int)point;
    }

    public void EndGame()
    {
        isGameOver = true;
        Time.timeScale = 0;
    }

    private IEnumerator CountDown()
    {
        countDown.gameObject.SetActive(true);
        countDown.text = "3";
        yield return new WaitForSecondsRealtime(1);
        countDown.text = "2";
        yield return new WaitForSecondsRealtime(1);
        countDown.text = "1";
        yield return new WaitForSecondsRealtime(1);
        countDown.text = "go";
        yield return new WaitForSecondsRealtime(1);
        countDown.gameObject.SetActive(false);
        Time.timeScale = 1;
        isGameStart = true;
    }
}