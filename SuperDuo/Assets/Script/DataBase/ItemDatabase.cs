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
    int id;
    string name;
    string content;
    int buy;
    int sell;
    int worth;
    Sprite icon;

    enum Kind {
        Gun,
        Bomb,
        Sword,
        Shuriken,
        Turret,
        Bow
    };

    int dmg;
    int builed;
    int reqBuiledMoney;
    int upBuiledMoney;
    float atkDelayTime;
    GameObject bullet;
    Sprite wear;
    AudioClip[] audioList;
}

public class Goods 
{
    int id;
    string name;
    string content;
    int buy;
    int sell;
    int worth;
    Sprite icon;
}


public class Avatar 
{
    int id;
    string name;
    string content;
    int buy;
    int sell;
    int worth;
    Sprite icon;

    int blockPoint;
    int look;
    Sprite wear;
}