using UnityEngine;

public class PlayerRay : MonoBehaviour
{

    public LayerMask targetLayer;
    [SerializeField] private float layerLength;
    private void Update()
    {
        //X������ �ȿ����̴� �� ������Ʈ�� ���� �ϳ� ����� �װ��� ���̸� ������Ű��
        //�����̴� Layer�±��� ������Ʈ�� �����ϸ� �ȴ�

        Debug.DrawRay(transform.position, Vector2.up * layerLength, Color.red);
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, layerLength,targetLayer);






    }


}
