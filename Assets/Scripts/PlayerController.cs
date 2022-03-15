using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private float speed = 10f;
    private float rotationspeed = 100f;
    private float verticalInput;
    private float horizontalInput;
    
    private bool ItsOnGround = false;
    public int CounterCoins;

    private Vector3 restartVehicleNum = new Vector3(0, 0.3f, 0);
    private Quaternion restartVehicleRotation = Quaternion.Euler(0, 0, 0);
    private Vector3 CoinSpawnPos = new Vector3(55.74f, 3.46f, 180.19f);

    private float CoolDownTime = 5f;
    private float NextRestart;

    private Vector3 SpawnPoint = new Vector3(-2.206353f, -1.443f, 9.473548f);

    public ParticleSystem Running_particle;
    public ParticleSystem Running_particle_2;
    public ParticleSystem RecolectParticle;

    public AudioClip movementAudioClip;
    public AudioClip shottingAudioClip;
    public AudioClip explosionAudioClip;

    public GameObject CoinsSpawn;
    public GameObject projectilePrefab;

    private GameManager GameManagerScript;

    private Animator PlayerAnimator;




    // Start is called before the first frame update
    void Start()
    {

        GameManagerScript = FindObjectOfType<GameManager>();
       
        transform.position = SpawnPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManagerScript.PlayerLife <= 0)
        {
            GameManagerScript.GameOver();
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
        

        //Disparo

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.85f, gameObject.transform.position.z), gameObject.transform.rotation);

            //PlayerAnimator.SetTrigger("Shotting");
        }


        //Reset con CoolDown
        if(Time.time > NextRestart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.position = transform.position + restartVehicleNum;
                transform.rotation = restartVehicleRotation;
                NextRestart = Time.time + CoolDownTime;
            }
        }


        //PARTICULAS

        if (ItsOnGround == true && transform.rotation.x <= 20 && verticalInput != 0)
        {
            //  Running_particle.Play();
            // Running_particle_2.Play();
            Running_particle.gameObject.SetActive(true);
            Running_particle_2.gameObject.SetActive(true);


        }
        else
        {
            // Running_particle.Pause();
            //Running_particle_2.Pause();  
            Running_particle.gameObject.SetActive(false);
            Running_particle_2.gameObject.SetActive(false);
        }


        //TESTEO PARA SCENA 2  BORRAR MÁS TARDE

        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.position = new Vector3(-23.6f, 10.69f, 65.5f);
        }

        if (GameManagerScript.counter >= 3)
        {
            Instantiate(CoinsSpawn, CoinSpawnPos, CoinsSpawn.transform.rotation);
            GameManagerScript.counter = 0;
        }
    }

    //Detectar colision con el suelo + Evitar subir montañas
    void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Ground"))
        {
            ItsOnGround = true;
        }


        if (otherCollider.gameObject.CompareTag("TP") && CounterCoins >= 3)
        {
            SceneManager.LoadScene(2);
            Debug.Log("FUNCIONA");
        }
        
        if (otherCollider.gameObject.CompareTag("TP") && CounterCoins <= 3)
        {
            Debug.Log("Necesitas 3 modenas para poder activar este teletransportador");
        }
       
    }

    //Recolector de monedas
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("coin"))
        {
            GameManagerScript.counter++;
            Debug.Log($"Has conseguido{CounterCoins}, ¡Sigue Así!");
            Destroy(otherCollider.gameObject);
            Instantiate(RecolectParticle, transform.position, transform.rotation);
        }

        
    }




}
