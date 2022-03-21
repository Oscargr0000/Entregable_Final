using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenEnemy : MonoBehaviour
{
    private GameObject player;
    private float speed = 5f;
    public int ChikenDamage = 10;

    private GameManager gameManagerScript;
    private AudioManager AudioManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("TANK");

        gameManagerScript = FindObjectOfType<GameManager>();
        AudioManagerScript = FindObjectOfType<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.gameOver == true)
        {
            speed = 0f;
        }

        if(gameManagerScript.win == true)
        {
            ChikenDamage = 0;
            speed = 0;
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        if (gameManagerScript.gameOver ==false)
        {
            transform.LookAt(player.transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TANK"))
        {
            gameManagerScript.PlayerLife -= ChikenDamage;
            Debug.Log(gameManagerScript.PlayerLife);
            AudioManagerScript.PlaySound(5);
            
            
        }
    }
}
