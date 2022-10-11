using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainGateAnimation : MonoBehaviour
{
    public TP_Activation _TPa;
    public Animator _animator;
    [SerializeField] private GameObject[] _gateColliders;
    
    public AudioSource gateImpactOne;
    public AudioSource gateImpactTwo;

    public Chain_L _ChainL; //assigner le GO de la "chain" correspondante ajoutera aussi le script nécessaire
    public Chain_R _ChainR;

    

    private void Start()
    {
        _animator = GetComponent<Animator>();

    }

    void Update()
    { 
        GateDown();
        
       // ChainCut();
    }
    
    // ChainCut() - Pour lancer le son en suppression des GO chaînes
   
    
    public void GateDown()
   {
       if (_ChainL.leftChainIsBroken == true && _ChainR.rightChainIsBroken == true)
       {
           _animator.SetBool("isBroken", true);
           _TPa.TplanesAtrium();

           StartCoroutine(FadeDuration(3f));
       }
   }
 
    IEnumerator FadeDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        _ChainL.leftChain.SetActive(false);
        _ChainR.rightChain.SetActive(false);
    }

    private void GateImpactOne()
    {
        gateImpactOne.Play();
    }
    private void GateColliderSwap()
    {
        _gateColliders[0].SetActive(false);
        _gateColliders[1].SetActive(true);
    }


    /*private void ChainCut()
    {
        if (chain_L == null)
        {
            chain_Cut_L.SetActive(true);
        }
        if (chain_R == null)
        {
            chain_Cut_R.SetActive(true);
        }
    }*/

}
