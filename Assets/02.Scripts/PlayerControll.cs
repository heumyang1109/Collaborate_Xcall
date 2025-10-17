using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [Header("캐릭터 설정")]
    [SerializeField] private float jumpFos = 5.5f;
    [SerializeField] private float rotationSpeed = 5.5f;

    private GameManager gameManager;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void Update()
    {
        if (gameManager == null || !gameManager.isGameStart)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.Instance.PlayJumpSound();
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
                AudioManager.Instance.PlayGameOverSound();
                gameManager.EndGame();

            }
        }
        //태그Wall에 닿으면 겜끝
    }



}