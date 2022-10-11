using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class SingleDoorTrigger : MonoBehaviour
{

    [SerializeField] private GameObject _allume;
    [SerializeField] private GameObject _eteinte;
    [SerializeField] private GameObject _highLight;
    
    
    public int triggerID;
    private bool _playerDetected=false;
    private bool _actif=false;

    private void Update()
    {
        PlayerDetected();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerDetected = false;
            _actif = false;
            _eteinte.SetActive(true);
            _allume.SetActive(false);
        }
    }

    private void PlayerDetected()
    {
        if (_playerDetected==true && Input.GetKeyDown(KeyCode.E))
        {
            if (_actif==false)
            {
                EventManager.StartDoorEvent(triggerID);
            }
        }

        if (_playerDetected==true)
        {
            _highLight.SetActive(true);
        }
        else
        {
            _highLight.SetActive(false);
        }

        if (_highLight.activeSelf==true && Input.GetKeyDown(KeyCode.E))
        {
            if (_actif==false)
            {
                _actif = true;
                _eteinte.SetActive(false);
                _allume.SetActive(true);
            }
            else
            {
                _actif = false;
                _eteinte.SetActive(true);
                _allume.SetActive(false);
            }
        }
    }
}
