using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour
{

    // Use this for initialization
    public GameObject leftPlayer;
    public GameObject rightPlayer;

    void Start()
    {
    }

    void Update()
    {

        Touch[] touches = Input.touches;


        Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        


        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 screenPos = new Vector3(touches[i].position.x, touches[i].position.y, 10); //터치를 입력받아요.
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos); // 월드 좌표로 변경해서 적용해요.
            Transform playerTransform;

            if (Camera.main.ScreenToViewportPoint(touches[i].position).x < 0.5)
                playerTransform = leftPlayer.transform;
            else
                playerTransform = rightPlayer.transform;

            Ray2D ray = new Ray2D(worldPos, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.CompareTag("item"))
            {
                playerTransform.GetComponent<Player>().control.weaponId = hit.collider.GetComponent<Item>().id;
                playerTransform.GetComponent<Player>().basebulletNum = hit.collider.GetComponent<Item>().b;
                playerTransform.GetComponent<Player>().bulletNum = hit.collider.GetComponent<Item>().b;
                Destroy(hit.collider.gameObject);
            }

            float rotatedegree = Mathf.Atan2((worldPos.y - playerTransform.position.y), (worldPos.x - playerTransform.position.x)) * Mathf.Rad2Deg; // 각도를 계산해요.

            playerTransform.rotation = Quaternion.Euler(playerTransform.rotation.x, playerTransform.rotation.y, rotatedegree); // 돌려요.

            playerTransform.GetComponent<Player>().shot = true;
            
        }
    }
}
