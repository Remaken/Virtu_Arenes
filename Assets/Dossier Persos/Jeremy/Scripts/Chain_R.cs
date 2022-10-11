using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_R : MonoBehaviour
{
    
    public bool rightChainIsBroken = false;
    public Transform rightChainFinalPlace;
    public float maxDistance;
    public GameObject rightChain;
    public GameObject chain_Cut_R;

    private void Update()
    {
        ChainTranslate();
    }
    public void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.CompareTag("Epee"))
        {
            rightChainIsBroken = true;
        }
        
        
    }
    
    public void ChainTranslate()
    {
        if (rightChainIsBroken)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightChainFinalPlace.position, maxDistance * Time.deltaTime);
            chain_Cut_R.SetActive(true);
        }
        
    }
}
