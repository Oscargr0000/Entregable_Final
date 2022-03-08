using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject ChickenEnemy;

    public int TotalEnemy = 1;
    private int EnemyLeft;


    // Start is called before the first frame update
    void Start()
    {
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

        return new Vector3(xRandom,4, zRandom);
    }

    void SpawnEnemy()
    {
        Instantiate(ChickenEnemy, RandomSpawnPostion(), ChickenEnemy.transform.rotation);
    }

    public void SpawnEnemyWave(int enemyInMap)
    {
        for (int i = 0; i < enemyInMap; i++)
        {
            SpawnEnemy();
        }
    }
}
