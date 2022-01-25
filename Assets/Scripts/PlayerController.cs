using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 10f;
    private float rotationspeed = 100f;
    private float verticalInput;
    private float horizontalInput;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Forward movement
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        //Rotation movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotationspeed * Time.deltaTime * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.85f, gameObject.transform.position.z), gameObject.transform.rotation);
        }
    }
}
