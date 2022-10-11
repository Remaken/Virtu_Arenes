using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_L : MonoBehaviour
{
    
    public bool leftChainIsBroken = false;
    public Transform leftChainFinalPlace;
    public float maxDistance;
    public GameObject leftChain;
    public GameObject chain_Cut_L;
    
    private void Update()
    {
        ChainTranslate();
    }
    public void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.CompareTag("Epee"))
        {
            leftChainIsBroken = true;
        }

    }
    
    public void ChainTranslate()
    {
        if (leftChainIsBroken)
        {
            chain_Cut_L.SetActive(true);
            transform.position = Vector3.MoveTowards(transform.position, leftChainFinalPlace.position, maxDistance * Time.deltaTime);
        }

    }

   
}
