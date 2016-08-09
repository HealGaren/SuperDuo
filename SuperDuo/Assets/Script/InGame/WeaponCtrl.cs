using UnityEngine;


//스테이지내의 무기 클래스입니다.
public class WeaponCtrl : MonoBehaviour {

    public Weapon weapon =  new Weapon();

    public float pulsDMG = 0;

    //투사체 초기 위치
    public GameObject bulletPos;

    //최적화를 위한 캐싱
    Transform tr;
    Rigidbody2D ri;
    Animator ani;
    AudioSource sound;
    PlayerCtrl player;

    //오브젝트 행동이 시작될 때 
    void Start () {
        //캐싱 작업
        tr = GetComponent<Transform>();
        ri = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        player = transform.root.GetComponent<PlayerCtrl>();

        //무기의 정보를 보냅니다.
        player.GetWeaponCtrl(this);
	}

    //매 프레임 마다 실행
    void Update () {
	
	}

    public void GetWearWeapon() {

    }

    public void Shot() {
        int i = 0;
        BulletCtrl ctrl = new BulletCtrl();

        //리스트에서 오브젝트를 찾아요.
        for (i = 0; i < GameManager.instance.Bullets.Count; i++) {
            if (GameManager.instance.Bullets[i].CompareTag(weapon.bullet.tag) && GameManager.instance.Bullets[i].activeSelf == false) {
                GameManager.instance.Bullets[i].transform.position = bulletPos.transform.position;
                GameManager.instance.Bullets[i].transform.rotation = bulletPos.transform.rotation;
                ctrl = GameManager.instance.Bullets[i].GetComponent<BulletCtrl>();
                GameManager.instance.Bullets[i].SetActive(true);
                break;
            }
        }
        //없으면 생성해요.
        if(i == GameManager.instance.Bullets.Count)
        {
            GameObject temp = Instantiate(weapon.bullet, bulletPos.transform.position, bulletPos.transform.rotation) as GameObject;
            ctrl = temp.GetComponent<BulletCtrl>();
            
        }

        //투사체 세팅을 해요.
        ctrl.dmg = (weapon.dmg * weapon.builed) + pulsDMG;
        ctrl.speed = weapon.bulletSpeed;


    }

}
