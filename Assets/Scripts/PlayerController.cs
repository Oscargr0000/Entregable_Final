using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Movement of the player
    private float speed = 10f;
    private float rotationspeed = 100f;
    private float verticalInput;
    private float horizontalInput;

    //Positions
    private Vector3 SpawnPoint = new Vector3(-2.206353f, -1.443f, 9.473548f);
    private Vector3 restartVehicleNum = new Vector3(0, 0.3f, 0);
    private Quaternion restartVehicleRotation = Quaternion.Euler(0, 0, 0);
    private Vector3 CoinSpawnPos = new Vector3(55.74f, 3.46f, 180.19f);

    //General
    private bool ItsOnGround = false;
    public int CounterCoins;
    private float CoolDownTime = 5f;
    private float NextRestart;

    
    //Particle
    public ParticleSystem Running_particle;
    public ParticleSystem Running_particle_2;
    public ParticleSystem RecolectParticle;

    //Prefabs
    public GameObject CoinsSpawn;
    public GameObject projectilePrefab;

    
    //Animations
    public Animator PlayerAnimator;

    //Connecting Scripts
    private GameManager GameManagerScript;
    private SpawnManager SpawnManagerScript;
    private AudioManager AudioManagerScript;
    private MenuManager MenuManagerScript;

    //UI
    public GameObject UItuto;




    void Start()
    {

        GameManagerScript = FindObjectOfType<GameManager>();
        AudioManagerScript = FindObjectOfType<AudioManager>();
        MenuManagerScript = FindObjectOfType<MenuManager>();

        transform.position = SpawnPoint;
    }

    void Update()
    {
        if(GameManagerScript.PlayerLife <= 0)
        {
            GameOver();
        }



        if (ItsOnGround == true)
        {
            //Forward movement
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

            //Rotation movement
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * rotationspeed * Time.deltaTime * horizontalInput);
        }
        

        //Shot

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.85f, gameObject.transform.position.z), gameObject.transform.rotation);
            AudioManagerScript.PlaySound(2);

            PlayerAnimator.SetTrigger("Shot");
        }


        //Reset with CoolDown
        if(Time.time > NextRestart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.position = transform.position + restartVehicleNum;
                transform.rotation = restartVehicleRotation;
                NextRestart = Time.time + CoolDownTime;
            }
        }


        //Particle

        if (ItsOnGround == true && transform.rotation.x <= 20 && verticalInput != 0)
        {
            Running_particle.gameObject.SetActive(true);
            Running_particle_2.gameObject.SetActive(true);
        }
        else
        {
            Running_particle.gameObject.SetActive(false);
            Running_particle_2.gameObject.SetActive(false);
        }

        //Coin
        if (GameManagerScript.counter >= 3)
        {
            Instantiate(CoinsSpawn, CoinSpawnPos, CoinsSpawn.transform.rotation);
            GameManagerScript.counter = 0;
        }
    }

    //Detect the colision with the floor to prevent climbing the mountain
    void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Ground"))
        {
            ItsOnGround = true;
        }

        // TP
        if (otherCollider.gameObject.CompareTag("TP") && CounterCoins >= 3)
        {
            SceneManager.LoadScene(2);
        }
       
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("TP") && CounterCoins <= 3) // NO TP
        {
            UItuto.SetActive(true);
        }
        else
        {
            UItuto.SetActive(false);
        }
    }

    //Recolector de monedas
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("coin")) // What is happening when you pick up a coin
        {
            CounterCoins++;
            Debug.Log($"Has conseguido{CounterCoins}, ¡Sigue Así!");
            Destroy(otherCollider.gameObject);
            Instantiate(RecolectParticle, transform.position, transform.rotation);
            AudioManagerScript.PlaySound(1);
        }

        if (otherCollider.gameObject.CompareTag("SuperCoin")) // When you are gonna win and what is happening when you do it
        {
            CounterCoins++;
            Debug.Log($"Has conseguido{CounterCoins}, ¡Sigue Así!");
            Destroy(otherCollider.gameObject);
            Instantiate(RecolectParticle, transform.position, transform.rotation);
            AudioManagerScript.PlaySound(1);
            MenuManagerScript.WIN();
            speed = 0;
            rotationspeed = 0;
            GameManagerScript.win = true;
        }
    }

    public void GameOver()
    {
        GameManagerScript.gameOver = true;
        Destroy(gameObject);
        Instantiate(GameManagerScript.DeadParticle, transform.position, transform.rotation);
        MenuManagerScript.GAMEOVER();
    }

}
