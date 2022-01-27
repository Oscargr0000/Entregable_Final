using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoawrd : MonoBehaviour
{
    private float speed = 50f;

    private float ObjetivePoints;
    public GameObject CoinsSpawn;
    private Vector3 CoinSpawnPos = new Vector3(55.74f, 3.46f, 180.19f);
    private bool DestroyedObject;
    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (DestroyedObject == true)
        {
            counter++;
            if (counter <= 1)
            {
                Instantiate(CoinsSpawn, CoinSpawnPos, gameObject.transform.rotation); //ARREGLAR ESTO
            }
            
        }
        
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
            ObjetivePoints++;
            Destroy(otherCollider.gameObject);

            if (ObjetivePoints == 3)
            {
                DestroyedObject = true;
            }
        }
    }
}
