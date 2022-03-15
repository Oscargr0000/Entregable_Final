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

    private PlayerController PlayerControllerScript;

    void Start()
    {
        gameOver = false;
        PlayerControllerScript = FindObjectOfType<PlayerController>();
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
