using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenEnemy : MonoBehaviour
{
    private GameObject player;
    private float speed = 3f;
    public float ChikenDamage = 10f;

    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("TANK");

        gameManagerScript = GameObject.Find("TANK").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
       

        transform.LookAt(player.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TANK"))
        {
            //gameManagerScript.PlayerLife - 10f;
        }
    }
}
