using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Base_Socket_Interactions : MonoBehaviour
{
    [SerializeField] XRSocketInteractor snap;
    public bool snapOn = true;
    
   // public Animator _animator;
   
    private void OnEnable()
    {
        snap.selectEntered.AddListener(StartSnap);
        snap.selectExited.AddListener(StopSnap);
        
    }

    private void OnDisable()
    {
        snap.selectEntered.RemoveListener(StartSnap);
        snap.selectExited.RemoveListener(StopSnap);
    }


    private void Start()
    {
        snapOn = false;
    }

    public void StartSnap(SelectEnterEventArgs args)
    {
        
        snapOn = true;
        
        
        if (snap == true)
        {
            
            //Debug.Log(gameObject.name + " est snappé");
            
        }
        
    }
    
    public void StopSnap(SelectExitEventArgs args)
    {
        snapOn = false;
        
        if (!snapOn)
        {
            //Debug.Log( " aucun snap");
            
        }
        
    }
    
    
   
}
