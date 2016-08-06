using UnityEngine;
using System.Collections.Generic;

//스킬 데이터가 저장되는 클래스 입니다.
[System.Serializable]
public class SkillDatabase : MonoBehaviour {

    //싱글 톤 
    public static SkillDatabase instance;

    List<Skill> skills; 

    //싱글 톤 생성
	void Start () {
        if (instance == null)
            instance = this;
	}
	
}

//스킬 클래스
public class Skill {
    int id;
    string name;
    string content;
    int dmg;
    GameObject particle;
    Skillbuiled builed;
    Skillstage stage;
    int step;
    List<Skilleffect> effect;
    float delayTime;
}

//스킬 효과 클래스 
public class Skilleffect {
    int id;
    string name;
    float value;
}

class Skillbuiled{
    int id;
    string name;
    float value;
}

public class Skillstage
{
    int id;
    string name;
    int reqValue;
    float value;
}