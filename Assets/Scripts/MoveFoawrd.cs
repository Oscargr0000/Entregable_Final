using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoawrd : MonoBehaviour
{


    private float speed = 50f;

    public GameObject CoinsSpawn;
    private Vector3 CoinSpawnPos = new Vector3(55.74f, 3.46f, 180.19f);

    private GeneralController GeneralControllerScript;

    private float lifeTime = 5f;


    void Start()
    {
        GeneralControllerScript = GameObject.Find("TANK").GetComponent<GeneralController>();
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

        if (otherCollider.gameObject.CompareTag("objective"))
        {
            GeneralControllerScript.refreshCounter();
            Destroy(otherCollider.gameObject);
            Destroy(gameObject);


            if (GeneralControllerScript.Counter >= 3)
            {
                Instantiate(CoinsSpawn, CoinSpawnPos, gameObject.transform.rotation);
            }
        }
    }
}
