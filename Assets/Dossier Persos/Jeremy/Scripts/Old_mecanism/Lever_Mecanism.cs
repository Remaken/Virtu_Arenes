using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Lever_Mecanism : MonoBehaviour
{
    public GameObject sword;
    
    private void OnTriggerEnter(Collider other)     //fait apparaitre l'épée dans son socle
    {
        if (other.gameObject.CompareTag("Poignee"))
        {
            sword.SetActive(true);
            
        }
    }

    
    
    
}
