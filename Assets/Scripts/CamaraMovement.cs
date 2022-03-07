using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{   

    private Vector3 SpawnCamara = new Vector3(0, 0, 0);
    private Quaternion SpawnRotation = Quaternion.Euler(0, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        transform.position = SpawnCamara;
        transform.rotation = SpawnRotation;  
    }
    
}

