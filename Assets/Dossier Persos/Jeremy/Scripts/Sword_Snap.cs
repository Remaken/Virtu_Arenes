using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Sword_Snap : MonoBehaviour
{
    
    public XRSocketInteractor snap;
    public bool swordSnapOn;
    public GameObject leftFlambeau;
    
    
    public void Start()
    {
        swordSnapOn = false;
        snap.selectEntered.AddListener(StartSnapped);
        snap.selectExited.AddListener(StopSnapped);

    }
    
    public void OnEnable()
    {
        snap.selectEntered.AddListener(StartSnapped);
        snap.selectExited.AddListener(StopSnapped);
        
    }

    public void OnDisable()
    {
        snap.selectEntered.RemoveListener(StartSnapped);
        snap.selectExited.RemoveListener(StopSnapped);
    }

    public void StartSnapped(SelectEnterEventArgs args)
    {
        swordSnapOn = true;
        leftFlambeau.SetActive(true);
    }
    
    public void StopSnapped(SelectExitEventArgs args)
    {
        swordSnapOn = false;

    }
    
    
}
