using UnityEngine;
using System.Collections;

public class UserData {

    public static UserData instance;

    public int level = 1;
    public int hp = 400;
    public int dmg = 50;
    public int statusPoint = 0;
    public int currentEXP, maxEXP = 80;


    void ExpManager(int num) {
        if (currentEXP + num >= maxEXP)
        {
            ++level;
            maxEXP = 80 + (320 * (level - 1));
            hp += 20;
            dmg += 5;
            statusPoint += 5;
        }
        else
            currentEXP += num;
    }
	
}
