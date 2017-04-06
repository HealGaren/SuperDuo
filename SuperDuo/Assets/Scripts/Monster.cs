using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Monster : MonoBehaviour
{
    public int baseHp = 100, HP = 50, damage = 5, point = 0;
    public float baseSpeed = 5f;
    bool playerCk = true;

    public GameObject attack, damaged;
    public GameObject[] items = new GameObject[3];
    Rigidbody2D ri;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bullet")
        {
            //ri.AddForce(-transform.right * 2f,ForceMode2D.Impulse);   
            HP -= col.gameObject.GetComponent<Bullet>().dmg;
            if (col.gameObject.GetComponent<Bullet>().snipe == false)
                Destroy(col.gameObject);
            Vector2 sc = Camera.main.WorldToScreenPoint(transform.position);
            GameObject temp = (GameObject)Instantiate(damaged,sc, Quaternion.identity);
            temp.transform.parent = GameObject.Find("Canvas").transform.GetChild(0).transform;
            temp.GetComponent<Text>().text = col.gameObject.GetComponent<Bullet>().dmg.ToString();

            Destroy(temp, 0.8f);
        }
        if (HP <= 0)
        {
            Destroy(this.gameObject);
            GameManager.Score += point;

            float r = Random.Range(0, 100);
            if (r <= 40f)
            {
                int rand = Random.Range(0, 3);
                GameObject asd = (GameObject)Instantiate(items[rand], transform.position, Quaternion.identity);
                Destroy(asd, 2f);
            }
        }
        if (col.gameObject.tag == "Player")
        {
            playerCk = false;
            Destroy(this.gameObject);
        }
    }


    void Start()
    {
        int rand = (int)Random.Range(1, 2);

        GameObject asd;

        if (rand == 1)
        {
            asd = GameObject.Find("BlueMan");
        }
        else
        {
            asd = GameObject.Find("BlackMan");
        }

        if (asd)
        {
            float rotatedegree = Mathf.Atan2((asd.transform.position.y - transform.position.y), (asd.transform.position.x - transform.position.x)) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotatedegree);
        }

        int rand2 = (int)Random.Range(1, 5);
        switch (rand2)
        {
            case 1: GetComponent<SpriteRenderer>().color = Color.red; break;
            case 2: GetComponent<SpriteRenderer>().color = Color.yellow; break;
            case 3: GetComponent<SpriteRenderer>().color = Color.blue; break;
            case 4: GetComponent<SpriteRenderer>().color = Color.cyan; break;
            case 5: GetComponent<SpriteRenderer>().color = Color.green; break;
            default: break;
        }

        rand2 = (int)Random.Range(1, 3);

        HP = rand2 * baseHp;

        ri = GetComponent<Rigidbody2D>();

        Destroy(this.gameObject, 7f);

    }

    // Update is called once per frame
    void Update()
    {
        if (playerCk == true)
        {
            transform.Translate(baseSpeed * Time.deltaTime, 0, 0);
        }
    }
}

