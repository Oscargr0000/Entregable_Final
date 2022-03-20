using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveFoawrd : MonoBehaviour
{
    public GameObject SuperCoin;

    private float speed = 50f;

    public ParticleSystem explosionSystem;

    private GameManager GameManagerScript;

    private float lifeTime = 5f;

    public int bosshits;

    private AudioManager AudioManagerScript;



    void Start()
    {
        GameManagerScript = FindObjectOfType<GameManager>();
        AudioManagerScript = FindObjectOfType<AudioManager>();
    }


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Fence"))
        {
            Destroy(otherCollider.gameObject);
            Destroy(gameObject);
            Instantiate(explosionSystem, transform.position, transform.rotation);

            AudioManagerScript.PlaySound(3);
        }

        if (otherCollider.gameObject.CompareTag("Diana"))
        {
            Destroy(otherCollider.gameObject);
            Destroy(gameObject);
            GameManagerScript.counter++;
            Instantiate(explosionSystem, transform.position, transform.rotation);
            AudioManagerScript.PlaySound(3);
        }

        if (otherCollider.gameObject.CompareTag("Chiken"))
        {
            Destroy(otherCollider.gameObject);
            GameManagerScript.ChikensKilled++;
            Destroy(gameObject);
            Instantiate(explosionSystem, transform.position, transform.rotation);
            AudioManagerScript.PlaySound(3);
        }

        if (otherCollider.gameObject.CompareTag("Boss"))
        {
            GameManagerScript.BossHits++;
            Instantiate(explosionSystem, transform.position, transform.rotation);
            AudioManagerScript.PlaySound(6);

            if(GameManagerScript.BossHits >= 5)
            {
                Destroy(otherCollider.gameObject);
                Instantiate(SuperCoin, new Vector3(-23.6f, 4f, 65.5f), SuperCoin.transform.rotation);

            }
        }
    }
}
