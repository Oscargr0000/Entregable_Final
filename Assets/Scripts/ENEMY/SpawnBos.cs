using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBos : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Chicken;

    private void Start()
    {
        Instantiate(Boss, RandomSpawnPostion(), Boss.transform.rotation);
        Instantiate(Chicken, RandomSpawnPostion(), Chicken.transform.rotation);
        Instantiate(Chicken, RandomSpawnPostion(), Chicken.transform.rotation);
    }

    private Vector3 RandomSpawnPostion()
    {
        float xRandom = Random.Range(-32, -19);
        float zRandom = Random.Range(53, 70);

        return new Vector3(xRandom, 4, zRandom);
    }

}
