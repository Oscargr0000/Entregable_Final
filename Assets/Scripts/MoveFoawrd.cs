using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoawrd : MonoBehaviour
{


    private float speed = 50f;

    public ParticleSystem explosionSystem;

    private GameManager GameManagerScript;

    private float lifeTime = 5f;

    public int bosshits;


    void Start()
    {
        GameManagerScript = FindObjectOfType<GameManager>();
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
        }

        if (otherCollider.gameObject.CompareTag("Diana"))
        {
            Destroy(otherCollider.gameObject);
            Destroy(gameObject);
            GameManagerScript.counter++;
            Instantiate(explosionSystem, transform.position, transform.rotation);
        }

        if (otherCollider.gameObject.CompareTag("Chiken"))
        {
            Destroy(otherCollider.gameObject);
            Destroy(gameObject);
            Instantiate(explosionSystem, transform.position, transform.rotation);
        }

        if (otherCollider.gameObject.CompareTag("Boss"))
        {
            GameManagerScript.BossHits++;
            Instantiate(explosionSystem, transform.position, transform.rotation);
        }
    }
}
