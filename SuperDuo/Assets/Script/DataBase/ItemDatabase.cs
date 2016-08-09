using UnityEngine;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour
{

    public static ItemDatabase instance;

    public List<Weapon> weapons;
    public List<Goods> goods;
    public List<Avatar> avatars;

    //싱글 톤 생성
    void Start()
    {
        if (instance == null)
            instance = this;
    }

}

public class Weapon
{

    public enum Kind
    {
        Gun,
        Bomb,
        Sword,
        Shuriken,
        Turret,
        Bow
    };

    public int id;
    public string name;
    public string content;
    public int buy;
    public int sell;
    public int worth;
    public Sprite icon;


    public Kind kind;
    public int dmg;
    public int builed;
    public int reqBuiledMoney;
    public int upBuiledMoney;
    public float atkDelayTime;
    public GameObject bullet;
    public float bulletSpeed;
    public Sprite wear;
    public AudioClip[] audioList;
}

public class Goods
{
    public int id;
    public string name;
    public string content;
    public int buy;
    public int sell;
    public int worth;
    public Sprite icon;
}


public class Avatar
{
    public int id;
    public string name;
    public string content;
    public int buy;
    public int sell;
    public int worth;
    public Sprite icon;

    public int blockPoint;
    public int look;
    public Sprite wear;
}