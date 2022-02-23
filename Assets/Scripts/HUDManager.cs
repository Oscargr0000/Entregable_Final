using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{

    public TextMeshProUGUI pointsText;

    public TextMeshProUGUI HPtext;

    private GameManager GameManagerScript;

    
    // Start is called before the first frame update
    void Start()
    {
        GameManagerScript = GameObject.Find("TANK").GetComponent<GameManager>();
        pointsText.text = $"Monedas:{GameManagerScript.counter}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
