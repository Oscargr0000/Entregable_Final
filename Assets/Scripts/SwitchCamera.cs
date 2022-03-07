using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{

    GameObject camera;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera"); ;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TANK")){ 
        camera.transform.position = this.transform.position;
        camera.transform.rotation = this.transform.rotation;
        }
    }
}
