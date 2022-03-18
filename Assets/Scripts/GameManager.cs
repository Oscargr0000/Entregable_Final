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

    //Game Over
    public bool gameOver;
    public ParticleSystem DeadParticle;

    //UI
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HealthUI;

    public GameObject WASD;
    public GameObject RestartPos;
    public GameObject Coins;
    public GameObject Shot;
    //public GameObject Shotting;

    private PlayerController PlayerControllerScript;
    private SpawnManager spawnManagerScript;
    private SpawnBos SpawnBossScript;
    private AudioManager AudioManagerScript;
   

    private bool WIN;

    public int ChikensKilled;

    void Start()
    {
        
        PlayerControllerScript = FindObjectOfType<PlayerController>();
        spawnManagerScript = FindObjectOfType<SpawnManager>();
        SpawnBossScript = FindObjectOfType<SpawnBos>();
        AudioManagerScript = FindObjectOfType<AudioManager>();

        

        SpawnBossScript.enabled = false;
        spawnManagerScript.enabled = false;

        AudioManagerScript.PlaySound(0);


        WIN = false;
        gameOver = false;

    }

    private void Update()
    {

        if(spawnManagerScript.TotalEnemy == 3)
        {
            spawnManagerScript.enabled = false;
        }

        if(ChikensKilled >= 6)
        {
            SpawnBossScript.enabled = true;
        }


    }
    

    public void WIIN()
    {
        WIN = true;
        
    }

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
