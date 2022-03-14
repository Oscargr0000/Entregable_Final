using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateChiken : MonoBehaviour
{
    private SpawnManager SpawnManagerScript;

    public GameObject Barrier;

    // Start is called before the first frame update
    void Start()
    {
        SpawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        
        SpawnManagerScript.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("TANK"))
        {

            Barrier.SetActive(true);
            
            SpawnManagerScript.enabled = true;

            Destroy(gameObject);
        }
    }
}
