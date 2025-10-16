using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private TextMeshProUGUI currnetTimeText;
    [SerializeField] private TextMeshProUGUI countDown;
    [SerializeField] private TextMeshProUGUI passingPoint;
    private bool isGameOver;
    private float currentTime;
    public float point;
    private void Start()
    {
        isGameOver = false;
        currentTime = 0f;
        
        Time.timeScale = 0; // <<게임내 시간조절하는변수 1 정상 0 일시정지(멈춤) 2 2배속
        StartCoroutine(CountDown());
    }
    private void Update()
    {
        
        
        
        if (isGameOver)
        {
            gameOverText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("SampleScene");
            }

        }
        currentTime += Time.deltaTime;
        currnetTimeText.text = ""+(int)currentTime;

        
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

    }
    
    
   


}
