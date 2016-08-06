using UnityEngine;
using System.Collections;


//스테이지내의 무기 클래스입니다.
public class WeaponCtrl : MonoBehaviour {

    public Weapon weapon =  new Weapon();

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
}
