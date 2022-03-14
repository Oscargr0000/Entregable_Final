using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int counter;

    public ParticleSystem DeadParticle;

    public float PlayerLife = 100f;

    public bool gameOver;

    public int BossHits;

    void Start()
    {
        gameOver = false;
    }

    private void Update()
    {
        if(PlayerLife <= 0)
        {

            GameOver();
        }
    }
    public void GameOver()
    {
        gameOver = true;
        Destroy(gameObject);
        Instantiate(DeadParticle, transform.position, transform.rotation);
    }

}
