using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject ChickenEnemy;

    private int TotalEnemy = 0;
    private int EnemyLeft;

    //private int SpawnPosEnemy = 5;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ChickenEnemy, RandomSpawnPostion(), ChickenEnemy.transform.rotation); // test
        SpawnEnemyWave(TotalEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyLeft = FindObjectsOfType<ChickenEnemy>().Length;
        if (EnemyLeft <= 0)
        {
            TotalEnemy++;
            SpawnEnemyWave(TotalEnemy);
        }
    }

    private Vector3 RandomSpawnPostion()
    {
        float xRandom = Random.Range(-32,-19);
        float zRandom = Random.Range(53,70);

        return new Vector3(xRandom, 10, zRandom);
    }

    void SpawnEnemy()
    {
        Instantiate(ChickenEnemy, RandomSpawnPostion(), ChickenEnemy.transform.rotation);
    }

    void SpawnEnemyWave(int enemyInMap)
    {
        for (int i = 0; i < enemyInMap; i++)
        {
            SpawnEnemy();
        }
    }
}
