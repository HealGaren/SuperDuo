using UnityEngine;
using System.Collections.Generic;

//게임 플레이를 관리하는 매니저 입니다.
public class GameManager : MonoBehaviour {

    //싱글 톤
    public static GameManager instance;
    //총알 오브젝트를 관리하는 리스트
    public List<GameObject> Bullets;
    //몬스터 오브젝트를 관리하는 리스트
    public List<GameObject> Monsters;

    Stage stage;

    //초기 세팅
    void Start()
    {
        //싱글 톤 생성
        if (instance == null)
            instance = this;
    }

    // 프레임 단위로 실행
    void Update () {
	
	}


}
