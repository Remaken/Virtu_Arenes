using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Statue : MonoBehaviour
{
    public delegate void EquipmentPlacedEvent();
    
    public static event EquipmentPlacedEvent HelmetWasPlaced;
    public static event EquipmentPlacedEvent ShieldPlaced;
    public static event EquipmentPlacedEvent SwordPlaced;
    public static event EquipmentPlacedEvent BreastPlatePlaced;
    
    public GameObject[] equipements;
    private bool _swordEquiped = false;
    private bool _shieldEquiped = false;
    private bool _helmetEquiped = false;
    private bool _breastPlateEquiped = false;
    private int _placedPieces = 0;
    public bool statueCompleted = false;

    
    //  NOTE :  Element 0 = Plastron  | Element 1 = Casque  | Element 2 = Epee  |  Element 3 = Bouclier  
    private void OnEnable()
    {
        Visiteur.ShieldWasTaken += ShieldEquiped;
        Visiteur.HelmetWasTaken += HelmetEquiped;
        Visiteur.SwordWasTaken += SwordEquiped;
        Visiteur.BreastPlateWasTaken += BreastPlateEquiped;
    }

    private void Update()
    {
        StatueComplete();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlacementBouclier();
            PlacementCasque();
            PlacementEpee();
            PlacementPlastron();
        }
    }

    private void  PlacementBouclier()
    {
        if (_shieldEquiped==true)
        {
            _shieldEquiped = false;
            equipements[3].SetActive(true);
            ShieldPlaced?.Invoke();
            
            if (_shieldEquiped==false)
            {
                _placedPieces++;
            }
        }

        if (Input.GetKeyDown(KeyCode.E)&& equipements[3].activeInHierarchy)
        {
            equipements[3].SetActive(false);
            _placedPieces--;
            
        }
    }
    private void  PlacementEpee()
    {
        if (_swordEquiped==true)
        {
            _swordEquiped = false;
            equipements[2].SetActive(true);
            SwordPlaced?.Invoke();
            
            if (_swordEquiped==false)
            {
                _placedPieces++;
            }
        }
    }
    private void PlacementPlastron()
    {
        if (_breastPlateEquiped==true)
        {
            _breastPlateEquiped = false;
            equipements[0].SetActive(true);
            BreastPlatePlaced?.Invoke();
            
            if (_breastPlateEquiped==false)
            {
                _placedPieces++;
            }
        }
    }
    private void  PlacementCasque()
    {
        if (_helmetEquiped==true)
        {
            _helmetEquiped = false;
            equipements[1].SetActive(true);
            HelmetWasPlaced?.Invoke();
            if (_helmetEquiped==false)
            {
                _placedPieces++;
            }
        }
    }
    
    private void ShieldEquiped()
    {
        _shieldEquiped = true;
    }
    private void SwordEquiped()
    {
        _swordEquiped = true;
    }
    private void BreastPlateEquiped()
    {
        _breastPlateEquiped = true;
    }
    private void HelmetEquiped()
    {
        _helmetEquiped = true;
    }

    private void StatueComplete()
    {
        if (_placedPieces>=4)
        {
            statueCompleted = true;
        }
    }
    private void OnDisable()
    {
        Visiteur.ShieldWasTaken -= ShieldEquiped;
        Visiteur.HelmetWasTaken -= HelmetEquiped;
        Visiteur.SwordWasTaken -= SwordEquiped;
        Visiteur.BreastPlateWasTaken -= BreastPlateEquiped;
    }
}
