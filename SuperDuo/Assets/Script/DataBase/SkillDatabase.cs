using UnityEngine;
using System.Collections.Generic;

//스킬 데이터가 저장되는 클래스 입니다.
[System.Serializable]
public class SkillDatabase : MonoBehaviour
{

    //싱글 톤 
    public static SkillDatabase instance;

    public List<Skill> skills;

    //싱글 톤 생성
    void Start()
    {
        if (instance == null)
            instance = this;
    }

}

//스킬 클래스
public class Skill
{
    public int id;
    public string name;
    public string content;
    public int dmg;
    public float range;
    public GameObject particle;
    public Skillbuiled builed;
    public Skillstage stage;
    public int step;
    public List<Skilleffect> effect;
    public float delayTime;
}

//스킬 효과 클래스 
public class Skilleffect
{
    public enum Effects
    {
        다단히트,
        격추,
        공격시간,
        공격횟수,
        공격불가,
        소환,
        넉백,
        이동속도,
        공격력강화,
        체력증가,
        지속시간,
        hp회복,
        쉴드획득,
        스턴
    };

    public Effects name;
    public float value;
}

public class Skillbuiled
{
    public int id;
    public string name;
    public float value;
}

public class Skillstage
{
    public int id;
    public string name;
    public int reqValue;
    public float value;
}

