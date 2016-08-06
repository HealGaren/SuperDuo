using UnityEngine;
using System.Collections;


//스테이지내의 플레이어 클래스입니다.
public class PlayerCtrl : MonoBehaviour {

    //HP
    public int currentHP, maxHP;
    //MP
    public int currentMP, maxMP;
    //공격력
    public int dmg;
    //방어력
    public int blockPoint;

    public Avatar avatar;

    //사운드 리스트
    public AudioClip[] audioList;

    //최적화를 위한 캐싱 변수
    Transform tr;
    Rigidbody2D ri;
    Animator ani;
    AudioSource sound;
    WeaponCtrl weapon;

    //오브젝트 행동이 시작될 때 
    void Start () {
        //캐싱 작업
        tr = GetComponent<Transform>();
        ri = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
	}
	
    //매 프레임 마다 실행
	void Update () {
	    
	}

    //착용 중인 무기의 정보를 받습니다.
    public void GetWeaponCtrl(WeaponCtrl w)
    {
        weapon = w;
    }

    public void GetWearAvatar(Avatar a) {
        avatar = a;
    }






}
