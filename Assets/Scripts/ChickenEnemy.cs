using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenEnemy : MonoBehaviour
{
    private GameObject player;
    private float speed = 5f;
    public float ChikenDamage = 10f;

    private GameManager gameManagerScript;

    public AudioClip ChikenSound;

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

        if(gameManagerScript.PlayerLife <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TANK"))
        {
            gameManagerScript.PlayerLife -= 10f;
            Debug.Log(gameManagerScript.PlayerLife);
        }
    }
}
