using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    
    // This MonoBehaviour is used in trigger and the UI we want is added in the inspector


    // UI
    public GameObject UI;

    private void Start()
    {
        UI.SetActive(false); // It first disable all the visibility of the UI
    }

    private void OnTriggerStay(Collider otherCollider)
    {
        // When the player is in the collider it will show up the UI, if he exit the collider, the UI, will be disable another time

        if (otherCollider.gameObject.CompareTag("TANK"))
        {
            UI.SetActive(true);
        }
        else
        {
            UI.SetActive(false);
        }

    }
}
