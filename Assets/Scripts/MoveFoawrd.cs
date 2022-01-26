using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoawrd : MonoBehaviour
{
    private float speed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
       
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Fence"))
        {
            Destroy(otherCollider.gameObject);
            Destroy(gameObject);
        }
    }
}
