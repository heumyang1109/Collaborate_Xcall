using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class Backup : MonoBehaviour
{
    /*
    
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
        currnetTimeText.text = "" + (int)currentTime;


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

    ===============================================================================

    [Header("캐릭터 설정")]
    [SerializeField] private float jumpFos = 5.5f;
    [SerializeField] private float rotationSpeed = 5.5f;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpFos, ForceMode2D.Impulse);
        }

        //캐릭터 몸 방향이 점프누를때 위로, 떨어질때 아래로
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
                
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {

            //FindObjectOfType<GameManager>().Endgame();

            GameManager gameManager = FindAnyObjectByType<GameManager>();
            if (gameManager != null)
            {
                gameManager.EndGame();
                
            }
        }
        //태그Wall에 닿으면 겜끝
    }

    ======================================================================================
    public LayerMask targetLayer;
    [SerializeField] private float layerLength;
    private void Update()
    {
        //X축으로 안움직이니 빈 오브젝트를 따로 하나 만들고 그곳에 레이를 고정시키고
        //움직이는 Layer태그의 오브젝트만 감지하면 된다

        Debug.DrawRay(transform.position, Vector2.up * layerLength, Color.red);
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, layerLength,targetLayer);






    }

}*/
