using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public int dmg = 1;
    public float speed = 20;
    public bool snipe = true;
    public bool shotgun = false;

    // Use this for initialization
    void Start()
    {
        if (shotgun)
        {
            Destroy(this.gameObject, 0.3f);
        }
        else
        {
            Destroy(this.gameObject, 2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }




}
