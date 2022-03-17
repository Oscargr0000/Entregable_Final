using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    

    public GameObject UI;

    private void Start()
    {
        UI.SetActive(false);
    }

    private void OnTriggerStay(Collider otherCollider)
    {
        //UI

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
