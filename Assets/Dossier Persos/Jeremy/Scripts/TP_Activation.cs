using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TP_Activation : MonoBehaviour
{
    
    public GameObject[] TPAreasAtrium;
    public GameObject[] TPAreasArena;
    
    public void TplanesAtrium()
    {
        for (int i = 0; i < TPAreasAtrium.Length; i++)
        {
            TPAreasAtrium[i].SetActive(true);
            
        }
    }
    
    public void TplanesArena()
    {
        for (int i = 0; i < TPAreasArena.Length; i++)
        {
            TPAreasArena[i].SetActive(true);
            
        }

    }
    
}
