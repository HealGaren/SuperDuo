using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    public int baseHP = 100, HP = 100, baseDmg = 1, basebulletNum = 9999, bulletNum = 9999;

    public GameObject shotPos;
    public GameObject[] bullets = new GameObject[4];
    public float bulletTimer = 0.5f, bulletDelay = 0f;
    public bool shot = false, twinkled = false;

    public Slider hpg;
    public Text hpt, weaoned, bullettxt;

    public WeaponControl control;

    public AudioClip[] audio = new AudioClip[4];

    public Sprite[] playerSprite = new Sprite[5];

    AudioSource au;
    Animator ani;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Mons")
        {
            HP -= col.gameObject.GetComponent<Monster>().damage;
            Destroy(col.gameObject);
        }

    }

    // Use this for initialization
    void Start()
    {
        au = GetComponent<AudioSource>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Round(HP * baseHP / 100) <= 20)
        {
            if (twinkled == false)
            {

                StartCoroutine("twinkle");

            }
        }
        else if (twinkled)
            twinkled = false;

        if (HP <= 0)
        {
            Destroy(this.gameObject);
            GameManager.instance.Die();
        }
        ShootUpdate();
        hpg.value = Mathf.Round(HP * baseHP / 100) / 100;
        hpt.text = HP.ToString() + " / " + baseHP.ToString();

        switch (control.weaponId)
        {
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = playerSprite[0];
                weaoned.text = "샷건"; bulletDelay = 0.5f;
                bullettxt.text = bulletNum.ToString() + " / " + basebulletNum.ToString(); break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = playerSprite[1];
                weaoned.text = "개틀링"; bulletDelay = 0.05f;
                bullettxt.text = bulletNum.ToString() + " / " + basebulletNum.ToString(); break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = playerSprite[2];
                weaoned.text = "활"; bulletDelay = 1f;
                bullettxt.text = bulletNum.ToString() + " /" + basebulletNum.ToString(); break;
            case 4:
                gameObject.GetComponent<SpriteRenderer>().sprite = playerSprite[3];
                weaoned.text = "권총"; bulletDelay = 0.2f; bullettxt.text = "∞ / ∞"; break;
            default: break;
        }


    }



    void ShootUpdate()
    {
        if (bulletTimer > bulletDelay && shot)
        {
            GameObject temp;

            switch (control.weaponId)
            {
                case 1:
                    temp = (GameObject)Instantiate(bullets[2], shotPos.transform.position, transform.rotation);
                    temp.GetComponent<Bullet>().dmg = baseDmg * 3; temp.GetComponent<Bullet>().speed *= 0;
                    au.PlayOneShot(audio[0]);
                    --bulletNum; break; //샷건
                case 2:
                    temp = (GameObject)Instantiate(bullets[1], shotPos.transform.position, transform.rotation);
                    temp.GetComponent<Bullet>().dmg = 30; temp.GetComponent<Bullet>().speed *= 3;
                    au.PlayOneShot(audio[1]);
                    --bulletNum; break;//개틀링
                case 3:
                    temp = (GameObject)Instantiate(bullets[3], shotPos.transform.position, transform.rotation);
                    temp.GetComponent<Bullet>().dmg = baseDmg * 10; temp.GetComponent<Bullet>().speed *= 5;
                    ani.SetBool("bow",true);
                    Invoke("delay", ani.GetCurrentAnimatorStateInfo(0).length);
                    au.PlayOneShot(audio[3]); --bulletNum; break; //활
                case 4:
                    temp = (GameObject)Instantiate(bullets[0],
                    shotPos.transform.position, transform.rotation);
                    temp.GetComponent<Bullet>().dmg = baseDmg * 2;
                    temp.GetComponent<Bullet>().speed *= 2;
                    au.PlayOneShot(audio[3]);
                    --bulletNum; break; //일반
                default: break;
            }
            if (bulletNum <= 0)
            {
                control.weaponId = 4;
            }
            shot = false;
            bulletTimer = 0f;
        }
        bulletTimer += Time.deltaTime;
    }

    void delay() {
        ani.SetBool("bow", false);
    }

    IEnumerator twinkle()
    {
        twinkled = true;
        while (twinkled)
        {
            yield return new WaitForSeconds(0.5f);
            if (hpg.transform.GetChild(1).GetChild(0).GetComponent<Image>().color == Color.yellow)
                hpg.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = Color.red;
            else
                hpg.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = Color.yellow;
        }
        hpg.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = Color.red;
        StopCoroutine("twinkle");


    }


}

