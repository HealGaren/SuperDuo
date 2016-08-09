using UnityEngine;
using System.Collections.Generic;

//몬스터 데이터가 저장되는 클래스 입니다.
[System.Serializable]
public class MonsterDatabase : MonoBehaviour
{
    //싱글 톤 
    public static MonsterDatabase instance;

    public List<MonsterShort> monstersShort;
    public List<MonsterLong> monstersLong;
    public List<MonsterCommand> monstersCommand;

    //싱글 톤 생성
    void Start()
    {
        if (instance == null)
            instance = this;
    }
}

public class MonsterShort
{
    public int id;
    public string name;
    public string content;
    public int dmg;
    public int hp;
    public float moveSpeed;
    public float atkDistance;
    public float atkDelayTime;
    public AudioClip[] audios;
    public Sprite sprite;
    public GameObject particle;
    
}

public class MonsterLong
{
    public int id;
    public string name;
    public string content;
    public int dmg;
    public int hp;
    public float moveSpeed;
    public float atkDistance;
    public float atkDelayTime;
    public AudioClip[] audios;
    public Sprite sprite;
    public GameObject bullet;
    public GameObject particle;
    
}

public class MonsterCommand
{
    public int id;
    public string name;
    public string content;
    public int dmg;
    public int hp;
    public float moveSpeed;
    public float atkSpeed;
    public float atkDistance;
    public float atkDelayTime;
    public AudioClip[] audios;
    public Sprite sprite;
    public GameObject summon;
    public GameObject particle;
   
}

