using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 10f;
    private float rotationspeed = 100f;
    private float verticalInput;
    private float horizontalInput;
    public GameObject projectilePrefab;
    private bool ItsOnGround = false;
    private int Counter;

    private Vector3 restartVehicleNum = new Vector3(0, 0.3f, 0);
    private Quaternion restartVehicleRotation = Quaternion.Euler(0, 0, 0);

    private float CoolDownTime = 5f;
    private float NextRestart;

    private Vector3 SpawnPoint = new Vector3(-2.206353f, -1.443f, 9.473548f);

    public ParticleSystem Running_particle;
    public ParticleSystem Running_particle_2;

    private float inMovement;

    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = SpawnPoint;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (ItsOnGround == true)
        {
            //Forward movement
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

            //Rotation movement
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * rotationspeed * Time.deltaTime * horizontalInput);
        }
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.85f, gameObject.transform.position.z), gameObject.transform.rotation);
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

        if (ItsOnGround == true && transform.rotation.x <= 20)
        {
            Running_particle.Play();
            Running_particle_2.Play();
        }
        else
        {
            Running_particle.Pause();
            Running_particle.Pause();          //ARREGLAR ESTO
        }
    }

    //Detectar colision con el suelo + Evitar subir montañas
    void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Ground"))
        {
            ItsOnGround = true;
        }

       
    }

    //Recolector de monedas
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("coin"))
        {
            Counter++;
            Debug.Log($"Has conseguido{Counter}, ¡Sigue Así!");
            Destroy(otherCollider.gameObject);
        }
    }
}
