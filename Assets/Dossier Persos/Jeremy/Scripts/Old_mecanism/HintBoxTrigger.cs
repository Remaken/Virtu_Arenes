using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintBoxTrigger : MonoBehaviour
{
    //public GameObject swordTriggerZone;
    
    private void OnTriggerStay(Collider other)      //active la boite signalant l'endroit où le joueur doit placer l'épée
                                                    //quand le joueur marche sur le ground
        
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Walking on Ground");
            //swordTriggerZone.SetActive(true);
        }
    }
    
}
