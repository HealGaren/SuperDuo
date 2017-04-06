using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponControl : MonoBehaviour {

    public int weaponId = 4;
    public Sprite[] icons = new Sprite[4];
    public Image icon;


    void Update() {
        icon.GetComponent<Image>().sprite = icons[weaponId-1];
    }



}
