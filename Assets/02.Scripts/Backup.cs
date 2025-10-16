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

        Time.timeScale = 0; // <<���ӳ� �ð������ϴº��� 1 ���� 0 �Ͻ�����(����) 2 2���
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

    [Header("ĳ���� ����")]
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

        //ĳ���� �� ������ ���������� ����, �������� �Ʒ���
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
        //�±�Wall�� ������ �׳�
    }

    ======================================================================================
    public LayerMask targetLayer;
    [SerializeField] private float layerLength;
    private void Update()
    {
        //X������ �ȿ����̴� �� ������Ʈ�� ���� �ϳ� ����� �װ��� ���̸� ������Ű��
        //�����̴� Layer�±��� ������Ʈ�� �����ϸ� �ȴ�

        Debug.DrawRay(transform.position, Vector2.up * layerLength, Color.red);
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, layerLength,targetLayer);






    }

}*/
