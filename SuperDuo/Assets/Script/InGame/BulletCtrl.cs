using UnityEngine;

//투사체를 관리하는 클래스입니다.
public class BulletCtrl : MonoBehaviour
{

    //스피드
    public float speed;
    //데미지
    public float dmg;
    //관통 여부
    public bool snipe = false;
    //타겟
    public GameObject target;
    //스킬 
    public Skill skill;

    //최적화를 위한 캐싱
    Transform tr;

    //초기 세팅
    void Start()
    {
        //캐싱
        tr = GetComponent<Transform>();

        //총알 오브젝트를 게임 매니저 클래스의 총알 리스트에 추가
        GameManager.instance.Bullets.Add(this.gameObject);
        //5초 후 오브젝트 풀링 
        Invoke("ObjPooling", 5f);
    }

    // 프레임 단위로 실행
    void Update()
    {
        //오른쪽으로 이동
        tr.Translate(Vector3.right * speed);
    }

    public void SetSkill(Skill sk)
    {
        //스킬을 적용
        skill = sk;
        //공격 효과를 적용
        Effects();
    }

    //오브젝트 풀링
    public void ObjPooling()
    {
        this.gameObject.SetActive(false);
    }

    void Effects()
    {
        for (int i = 0; i < skill.effect.Count; i++)
        {
            switch (skill.effect[i].name)
            {
                case Skilleffect.Effects.다단히트:
                    // 다단히트
                    break;
                case Skilleffect.Effects.격추:
                    // 격추
                    break;
                case Skilleffect.Effects.공격시간:
                    // 공격 시간
                    break;
                case Skilleffect.Effects.공격횟수:
                    // 공격 횟수
                    break;
                case Skilleffect.Effects.공격불가:
                    // 공격 불가
                    break;
                case Skilleffect.Effects.소환:
                    // 소환   
                    break;
                case Skilleffect.Effects.넉백:
                    // 넉백
                    break;
                case Skilleffect.Effects.이동속도:
                    // 이동속도
                    break;
                case Skilleffect.Effects.공격력강화:
                    // 공격력 강화
                    break;
                case Skilleffect.Effects.체력증가:
                    // 체력 증가
                    break;
                case Skilleffect.Effects.지속시간:
                    // 지속 시간
                    break;
                case Skilleffect.Effects.hp회복:
                    // hp 회복
                    break;
                case Skilleffect.Effects.쉴드획득:
                    //쉴드 획득
                    break;
                case Skilleffect.Effects.스턴:
                    // 스턴
                    break;

                default: // 정해져 있지 않은 효과입니다.
                    break;

            }
        }
    }

}
