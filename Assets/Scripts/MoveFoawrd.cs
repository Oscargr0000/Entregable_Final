using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoawrd : MonoBehaviour
{


    private float speed = 50f;

    

    private GameManager GameManagerScript;

    private float lifeTime = 5f;


    void Start()
    {
        GameManagerScript = GameObject.Find("TANK").GetComponent<GameManager>();
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
        }

        if (otherCollider.gameObject.CompareTag("Diana"))
        {
            Destroy(otherCollider.gameObject);
            Destroy(gameObject);
            GameManagerScript.counter++;
        }
    }
}
