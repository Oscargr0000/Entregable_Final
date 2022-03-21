using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //General
    public int counter;
    public float PlayerLife = 100f;

    //Boss
    public int BossHits;
    public int ChikensKilled;

    //Game Over
    public bool gameOver;
    public bool win;
    public ParticleSystem DeadParticle;

    //UI
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HealthUI;

    public GameObject WASD;
    public GameObject RestartPos;
    public GameObject Coins;
    public GameObject Shot;

    //Connecting Scripts
    private SpawnManager spawnManagerScript;
    private SpawnBos SpawnBossScript;
   
    
    

    void Start()
    {
        //Scripts
        spawnManagerScript = FindObjectOfType<SpawnManager>();
        SpawnBossScript = FindObjectOfType<SpawnBos>();

        //Disable the Scripts Because they will be call in a future moment
        SpawnBossScript.enabled = false;
        spawnManagerScript.enabled = false;
    
        //Game Over
        gameOver = false;

    }

    private void Update()
    {
        // Cancel the spawning of the chickens to bring pass the Boss Spawn Script
        if(spawnManagerScript.TotalEnemy == 3)
        {
            spawnManagerScript.enabled = false;
        }

        // Spawn the boss when all the chikens are dead
        if(ChikensKilled >= 6)
        {
            SpawnBossScript.enabled = true;
        }
    }
    

    
    // UI for HP and MONEY (No he conseguido que funcione)

    /*public void UpdateScore(int pointToAdd)
    {
        
        ScoreText.text = $"Monedas: {pointToAdd}";
    }

    public void UpdateLife(int Life)
    {
        PlayerLife -= Life;
        HealthUI.text = $"HP {Life}";
    }*/

}
