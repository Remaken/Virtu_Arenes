using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverManager : MonoBehaviour
{
    
    public XRGrabInteractable _grab;
    public GameObject[] hoveredHelmetParts;
    public Renderer[] hoveredInteractable;
    public bool isHightLighted = false;
    
    public GameObject torchGrabHighlight;

    

    public void OnEnable()
    {
        _grab.hoverEntered.AddListener(Highlight);
        _grab.hoverExited.AddListener(NotPointed);
        _grab.selectEntered.AddListener(Grabbed);
        _grab.selectExited.AddListener(NotGrabbed);
    }

    public void OnDisable()
    {
        _grab.hoverEntered.RemoveListener(Highlight);
        _grab.hoverExited.RemoveListener(NotPointed);
        _grab.selectEntered.RemoveListener(Grabbed);
        _grab.selectExited.RemoveListener(NotGrabbed);
    }

    public void NotPointed(HoverExitEventArgs args)
    {
        isHightLighted = false;
        
        foreach (Renderer go in hoveredInteractable)
        { 
            go.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");     //active l'emmission paramétrée en jaune sur chaque objet du tableau hoverHelmetParts
        }
        if(torchGrabHighlight != null) 
            torchGrabHighlight.SetActive(false);
    }
    
    public void Highlight(HoverEnterEventArgs args)
    {
        isHightLighted = true;

        foreach (Renderer go in hoveredInteractable)
        { go.GetComponent<Renderer>().material.EnableKeyword("_EMISSION"); } //active l'emmission paramétrée en jaune sur chaque objet du tableau hoverHelmetPa}
        if(torchGrabHighlight != null) 
            torchGrabHighlight.SetActive(true);
    }

    public void Grabbed(SelectEnterEventArgs args)
    {
        foreach (Renderer go in hoveredInteractable)
        { go.GetComponent<Renderer>().material.DisableKeyword("_EMISSION"); } //active l'emmission paramétrée en jaune sur chaque objet du tableau hoverHelmetParts
        if(torchGrabHighlight != null) 
            torchGrabHighlight.SetActive(false);
    }
    
    public void NotGrabbed(SelectExitEventArgs args)
    {
        foreach (Renderer go in hoveredInteractable)
        { go.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");  }   //active l'emmission paramétrée en jaune sur chaque objet du tableau hoverHelmetParts
        if(torchGrabHighlight != null) 
            torchGrabHighlight.SetActive(true);
    }
}
