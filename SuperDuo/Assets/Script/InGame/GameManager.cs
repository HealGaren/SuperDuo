using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//게임 플레이를 관리하는 매니저 입니다.
public class GameManager : MonoBehaviour {

    //싱글 톤
    public static GameManager instance;
    //총알 오브젝트를 관리하는 리스트
    public List<GameObject> Bullets;
    //몬스터 오브젝트를 관리하는 리스트
    public List<GameObject> Monsters;
    //플레이어를 관리 하는 리스트
    public GameObject[] player;

    //스테이지 정보
    public Stage stage = new Stage();
    //난이도
    public int Levels;

    //커멘드 피쉬 |  근,원거리 피쉬 | 패턴 수
    public int commandFishs,otherFishs,patern;
    int currentNum;
    int playTime;


    

    //초기 세팅
    void Start()
    {
        //싱글 톤 생성 << 매번 스테이지 접속시 초기화 해야함.
        instance = this;

    }

    public void ScoreSet() {
        ++currentNum;
    }

    void SpawnMonster() {
        ++otherFishs;
        int kind = Random.Range(0, 4);
        int rand =Random.Range(0, 100);

        switch (kind) {
            case 4:
                //원거리
                switch (rand)
                {
                    case 45:
                        //날치
                        break;
                    case 20:
                        //복어
                        break;
                    case 0:
                        //전기뱀장어
                        break;
                    default:
                        break;
                }
                break;
            case 0:
                //근거리
                switch (rand)
                {
                    case 70:
                        //잉어
                        break;
                    case 50:
                        //문어
                        break;
                    case 30:
                        //피라냐
                        break;
                    case 15:
                        //소라게
                        break;
                    case 5:
                        //거북
                        break;
                    case 0:
                        //상어
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }

       
    }

    void Fail() {

    }

    void Clear() {
        //평점 부여
        int total = (8 - playTime) +  ((player[1].GetComponent<PlayerCtrl>().currentHP + player[2].GetComponent<PlayerCtrl>().currentHP) / 20);
        //경험치 부여를 계산
        int addExp = total * Levels * 200;
        //무기를 드랍

        //버블을 드랍
        int bubblePay = 1000 * (Levels + UserData.instance.level);
        //아바타를 드랍
    }


    // 프레임 단위로 실행
    void Update () {
	
	}

    IEnumerator TimeUpdate() {
        while (true)
        {
            yield return new WaitForSeconds(60f);
            ++playTime;
        }
    }


}
