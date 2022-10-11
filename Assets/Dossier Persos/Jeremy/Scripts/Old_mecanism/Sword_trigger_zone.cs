using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Sword_trigger_zone : MonoBehaviour
{

    public GameObject swordPlaced;
    
    
    private void OnTriggerEnter(Collider other)     //affiche l'épée dans la main de la statue, une fois l'épée snappé sur le coté du piedestal
    {
        if (other.gameObject.CompareTag("Epee"))
        {
            Debug.Log("Sword is in the box");
            swordPlaced.SetActive(true);
            
        }
    }
}



