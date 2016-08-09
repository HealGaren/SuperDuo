using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public GameObject leftPlayer;
    public GameObject rightPlayer;
    public float centerPos;

    Ray2D ray;
    RaycastHit2D hit;
    Transform playerTransform;
    PlayerCtrl control;

    void Update()
    {
        //터치를 입력받아요.
        Touch[] touches = Input.touches;

        for (int i = 0; i < Input.touchCount; i++)
        {

            Vector3 screenPos = new Vector3(touches[i].position.x, touches[i].position.y, 10);
            // 월드 좌표로 변경해서 적용해요.
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos); 

            //센터를 기준으로 플레이어의 조작을 정해요.
            if (Camera.main.ScreenToViewportPoint(touches[i].position).x < centerPos)
                playerTransform = leftPlayer.transform;
            else
                playerTransform = rightPlayer.transform;

            //컨트롤을 부여해요.
            control = playerTransform.GetComponent<PlayerCtrl>();

            /*
            ray = new Ray2D(worldPos, Vector2.zero);
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            */

            // 각도를 계산해요.
            float rotatedegree = Mathf.Atan2((worldPos.y - playerTransform.position.y), (worldPos.x - playerTransform.position.x)) * Mathf.Rad2Deg;
            // 돌려요
            playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, Quaternion.Euler(0, 0, rotatedegree), Time.smoothDeltaTime * control.rotateSpeed);
            // 투사체를 날려요.
            control.weapon.Shot();
        }
    }
}
