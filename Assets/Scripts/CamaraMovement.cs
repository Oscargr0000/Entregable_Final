using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    private Vector3 CamPosition = new Vector3(-46.02564f, 8.420757f, 100.8163f);
    private Quaternion CamRotation = Quaternion.Euler(8.629f, 122.741f, 0.056f);
    
    private Vector3 CamPosition_2 = new Vector3(4.513609f, 19.30423f, 96.31001f);
    private Quaternion CamRotation_2 = Quaternion.Euler(30.975f, 73.261f, 0.065f);
    
    private Vector3 CamPosition_3 = new Vector3(30.48676f, 16.61137f, 158.7016f);
    private Quaternion CamRotation_3 = Quaternion.Euler(20.49f, 80.469f, 0.062f);

    private Vector3 SpawnCamara = new Vector3(0, 0, 0);


    private Quaternion SpawnRotation = Quaternion.Euler(0, 0, 0);
    private Transform PlayerPosition;


    private float PlayerLimitZ_1 = 50f;
    private float PlayerLimitX_1 = 7f;
    
    private float PlayerLimitZ_2 = 80f;
    private float PlayerLimitX_2 = 12f;
    
    private float PlayerLimitZ_3 = 146f;
    private float PlayerLimitX_3 = 45f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = SpawnCamara;
        transform.rotation = SpawnRotation;
        PlayerPosition = GameObject.Find("TANK").GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPosition.position.z >= PlayerLimitZ_1 && PlayerPosition.position.x <= PlayerLimitX_1)
        {
            transform.position = CamPosition;
            transform.rotation = CamRotation;
        }
        else
        {
            transform.position = SpawnCamara;
            transform.rotation = SpawnRotation;
        }
        
        if (PlayerPosition.position.z >= PlayerLimitZ_2 && PlayerPosition.position.x >= PlayerLimitX_2)
        {
            transform.position = CamPosition_2;
            transform.rotation = CamRotation_2;
        }
        
        if (PlayerPosition.position.z >= PlayerLimitZ_3 && PlayerPosition.position.x >= PlayerLimitX_3)
        {
            transform.position = CamPosition_3;
            transform.rotation = CamRotation_3;
        }

        
    }
}
