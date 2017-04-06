using UnityEngine;
using System.Collections;

public class spawnManager : MonoBehaviour
{
    public Vector3[,] positions = new Vector3[2, 100];
    float spawnTimer = 0;
    public bool isSpawn = false;
    public float spawnDelay = 0.5f;
    public GameObject Mons;



    void SpawnMons()
    {
        if (isSpawn == true)
        {
            if (spawnTimer > spawnDelay)
            {
                int randTen = Random.Range(0, 100);
                int randFour = Random.Range(0, 2);
                Instantiate(Mons, positions[randFour, randTen], Quaternion.identity);
                spawnTimer = 0f;
            }
            spawnTimer += Time.deltaTime;
        }
    }

    void CreatePosition()
    {
        float fixedPos = 1.1f;
        float movePos = 0;
        float gapPos = 1f / 100f;

        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i < 100; i++)
            {
                movePos = gapPos + gapPos * i;
                Vector3 viewPos = new Vector3(fixedPos, movePos, 0);
                Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);

                worldPos.z = 0;
                positions[j, i] = worldPos;
                print(positions[j,i]);
            }
            fixedPos = -fixedPos+1;
        }

       
    }


    // Use this for initialization
    void Start()
    {
        CreatePosition();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnMons();
    }
}
