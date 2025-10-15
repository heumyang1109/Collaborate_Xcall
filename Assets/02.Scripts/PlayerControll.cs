using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    
    [Header("캐릭터 설정")]
    [SerializeField] private float jumpFos = 5f;
    [SerializeField] private float rotationSpeed = 5f;

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
}
