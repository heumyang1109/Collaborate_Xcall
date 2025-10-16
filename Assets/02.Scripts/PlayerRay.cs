using UnityEngine;

public class PlayerRay : MonoBehaviour
{

    public LayerMask targetLayer;
    [SerializeField] private float layerLength;
    private void Update()
    {
        //X축으로 안움직이니 빈 오브젝트를 따로 하나 만들고 그곳에 레이를 고정시키고
        //움직이는 Layer태그의 오브젝트만 감지하면 된다

        Debug.DrawRay(transform.position, Vector2.up * layerLength, Color.red);
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, layerLength,targetLayer);






    }


}
