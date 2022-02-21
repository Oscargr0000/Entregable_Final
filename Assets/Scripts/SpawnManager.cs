using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ChickenEnemy;

    private int TotalEnemy = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ChickenEnemy, transform.position, ChickenEnemy.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < TotalEnemy; i++)
        {

        }
    }
}
