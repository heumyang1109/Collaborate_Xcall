using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    public LayerMask targetLayer;
    [SerializeField] private float layerLength;
    private GameManager gameManager;
    private bool hitWall = false;


    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void Update()
    {
        //X������ �ȿ����̴� �� ������Ʈ�� ���� �ϳ� ����� �װ��� ���̸� ������Ű��
        //�����̴� Layer�±��� ������Ʈ�� �����ϸ� �ȴ�

        Debug.DrawRay(transform.position, Vector2.up * layerLength, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, layerLength, targetLayer);

        if (hit.collider != null)
        {
            if (!hitWall)
            {
                gameManager.point += 1;
                hitWall = true;
                gameManager.passingPoint.text = "Score " + (int)gameManager.point;
                AudioManager.Instance.PlayCheckpointSound();
            }
        }
        else
        {
            hitWall = false;
        }




    }


}