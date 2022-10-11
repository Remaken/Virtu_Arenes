using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torche : MonoBehaviour
{
    public delegate void TorchEvent();

    public static event TorchEvent TorchHolding;
    private bool _playerContact=false;
    [SerializeField] private Visiteur PlayerManager;
    [SerializeField] private GameObject Combustible;
    [SerializeField] protected GameObject Lumiere;
    [SerializeField] private GameObject Eteint;
    
    private Vector3 _positionActuelleJoueur;

    /*private void OnEnable()
    {
        Visiteur.TorchDrop += PlayerPos;
    }*/

    private void Update()
    {
        GiveTorch();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _playerContact == false)
        {
            if (PlayerManager.holdingTorch == false)
            {
                _playerContact = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerContact = false;
        }
    }

    private void GiveTorch()
    {
        if (_playerContact == true && PlayerManager.holdingTorch == false && PlayerManager.leftHandOcupied==false)
        {
                TorchHolding?.Invoke();
                Visiteur.TorchDrop += TorchReset;
                gameObject.transform.position=PlayerManager.leftHand.transform.position;
                gameObject.transform.parent = PlayerManager.leftHand.transform;
                StartCoroutine(TorchLifeSpan());
        }
       
    }

    IEnumerator TorchLifeSpan()
    {
        yield return new WaitForSeconds(15f);
        Lumiere.SetActive(false);
        Combustible.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        Combustible.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.black);
        Eteint.SetActive(true);
    }
    
    /*private void PlayerPos()
    {
        _positionActuelleJoueur = PlayerManager.transform.position;
    }*/
    
    private void TorchReset()
    {
            PlayerManager.holdingTorch = false;
            _playerContact = false;
            Destroy(this.gameObject);
        
    }
    private void OnDisable()
    {
        Visiteur.TorchDrop -= TorchReset;
        //Visiteur.TorchDrop -= PlayerPos;
    }
}
