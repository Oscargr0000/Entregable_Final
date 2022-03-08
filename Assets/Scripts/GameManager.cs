using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int counter;

    public GameObject CoinsSpawn;
    private Vector3 CoinSpawnPos = new Vector3(55.74f, 3.46f, 180.19f);
    public ParticleSystem DeadParticle;

    public float PlayerLife = 100f;


    public bool gameOver;

    void Start()
    {
        gameOver = false;
    }

    private void Update()
    {
        if(counter >= 3)
        {
            Instantiate(CoinsSpawn, CoinSpawnPos, CoinsSpawn.transform.rotation);
            counter = 0;
        }

        if(PlayerLife <= 0)
        {

            GameOver();
        }
    }
    private void GameOver()
    {
        gameOver = true;
        Destroy(gameObject);
        Instantiate(DeadParticle, transform.position, transform.rotation);
    }

}
