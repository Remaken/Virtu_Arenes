using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_Sounds : MonoBehaviour
{
    public ActionBasedControllerManager a_Base;
    public AudioSource audio;
    public AudioClip clip;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void OnEnable()
    {
        //a_Base.teleportState.onEnter.AddListener(Sound);
        a_Base.teleportState.onExit.AddListener(Sound);
    }

    public void OnDisable()
    {
        //a_Base.teleportState.onEnter.RemoveListener(Sound);
        a_Base.teleportState.onExit.RemoveListener(Sound);
    }


    public void Sound(ActionBasedControllerManager.StateId args)
    {
        audio.PlayOneShot(clip);
    }
    
}
