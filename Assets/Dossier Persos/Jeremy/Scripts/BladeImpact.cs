using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeImpact : MonoBehaviour
{

    public AudioSource audio;
    
    public AudioClip stoneClip;
    public AudioClip woodClip;
    public AudioClip ironClip;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Stone"))
        {
            audio.PlayOneShot(stoneClip);
        }
        
        if (other.gameObject.CompareTag("Wood"))
        {
            audio.PlayOneShot(woodClip);
        }
        
        if (other.gameObject.CompareTag("Iron") || other.gameObject.CompareTag("Chain_L") || other.gameObject.CompareTag("Chain_R"))
        {
            audio.PlayOneShot(ironClip);
        }
    }
}
