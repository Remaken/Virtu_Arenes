using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_mecanism : MonoBehaviour
{
    
    public GameObject doorTrap;

    private void OnCollisionEnter(Collision other)      //desactive le piege du mur quand un objet possédant ce script
                                                        //entre en contact avec le socle de l'épée
    {
        if (other.gameObject.CompareTag("Base"))
        {
            doorTrap.SetActive(false);

        }
    }

    
}
