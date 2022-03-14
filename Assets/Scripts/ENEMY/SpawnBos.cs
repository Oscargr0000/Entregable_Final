using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBos : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Chicken;

    private SpawnManager SpawnManagerScript;

    private void Start()
    {
        SpawnManagerScript = FindObjectOfType<SpawnManager>();

        ActivateBoss(SpawnManagerScript.LeftToDestroy);
    }

    private void Update()
    {
        if (SpawnManagerScript.LeftToDestroy >= 4)
        {
            ActivateBoss(SpawnManagerScript.LeftToDestroy);
        }
    }

    void ActivateBoss(int EnemyDestroy)
    {
        if(EnemyDestroy >= 4)
        {
            Instantiate(Boss, RandomSpawnPostion(), Boss.transform.rotation);
            Instantiate(Chicken, RandomSpawnPostion(), Chicken.transform.rotation);
            Instantiate(Chicken, RandomSpawnPostion(), Chicken.transform.rotation);

            SpawnManagerScript.enabled = false;
        }
    }

    private Vector3 RandomSpawnPostion()
    {
        float xRandom = Random.Range(-32, -19);
        float zRandom = Random.Range(53, 70);

        return new Vector3(xRandom, 4, zRandom);
    }
}
