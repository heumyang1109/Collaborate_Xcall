using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    
    [Header("ĳ���� ����")]
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

        //ĳ���� �� ������ ���������� ����, �������� �Ʒ���
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }
}
