using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
public enum PlayerState
{
    None,
    Walking,
    HasSword,
    HasBreastPlate,
    HasShield,
    HasHelmet,
}
public class Visiteur : MonoBehaviour
{ 
    public delegate void TorchDropEvent();
    public delegate void EquipmentEvent();

    public static event TorchDropEvent TorchDrop;
    public static event EquipmentEvent HelmetWasTaken;
    public static event EquipmentEvent SwordWasTaken;
    public static event EquipmentEvent BreastPlateWasTaken;
    public static event EquipmentEvent ShieldWasTaken;
    
    public PlayerState state = PlayerState.None;
    public PlayerState nextState = PlayerState.None;

    [SerializeField] private float _moveSpeed = 5f;
    public GameObject rightHand;
    public GameObject leftHand;
    public bool leftHandOcupied =false;
    public bool rightHandOcupied =false;
    public GameObject dropZone;
    public bool holdingTorch = false;
    public GameObject[] equipements;
    
    
    //  NOTE :  Element 0 = Plastron  | Element 1 = Casque  | Element 2 = Epee  |  Element 3 = Bouclier  

    private void OnEnable()
    {
        Torche.TorchHolding += HoldTorch;
        Statue.ShieldPlaced += ShieldPlaced;
        Statue.SwordPlaced += SwordPlaced;
        Statue.HelmetWasPlaced += HelmetPlaced;
        Statue.BreastPlatePlaced += BreastPlatePlaced;
        
    }

    private void Start()
    {
        state = PlayerState.Walking;
    }
    
   private void Update()
    {
        if (CheckForTransition())
        {
            TransitionOrChangeState();
        }
        StateBehaviour();
        CanDrop();
        EquipObjects();
    }

  

   private void FixedUpdate()
    {
        PlayerMouvement();
    }


   private void OnCollisionEnter(Collision other)
   {
       if (other.gameObject.CompareTag("Bouclier") && leftHandOcupied==false)
       {
           other.gameObject.SetActive(false);
           equipements[3].SetActive(true);
           leftHandOcupied = true;
       }
       if (other.gameObject.CompareTag("Plastron"))
       {
           other.gameObject.SetActive(false);
           equipements[0].SetActive(true);
       }
       if (other.gameObject.CompareTag("Epee")&& rightHandOcupied==false)
       {
           other.gameObject.SetActive(false);
           equipements[2].SetActive(true);
           rightHandOcupied = true;
       }
       if (other.gameObject.CompareTag("Casque"))
       {
           other.gameObject.SetActive(false);
           equipements[1].SetActive(true);
       }
   }

   private void EquipObjects()
   {
       if (equipements[0].activeInHierarchy)
       {
           BreastPlateWasTaken?.Invoke();
       }
       if (equipements[1].activeInHierarchy)
       {
           HelmetWasTaken?.Invoke();
       }
       if (equipements[2].activeInHierarchy)
       {
           SwordWasTaken?.Invoke();
       }
       if (equipements[3].activeInHierarchy)
       {
           ShieldWasTaken?.Invoke();
       }
       
   }
   private bool CheckForTransition()
    {
        switch (state)
        {
            case PlayerState.None:
                break;
            case PlayerState.Walking:
                break;
            case PlayerState.HasHelmet:
                break;
            case PlayerState.HasShield:
                break;
            case PlayerState.HasSword:
                break;
            case PlayerState.HasBreastPlate:
                break;
        }
        return false;
    }

    private void TransitionOrChangeState()
    {
        switch (nextState)
        {
            case PlayerState.None:
                break; 
            case PlayerState.Walking:
                break;
            case PlayerState.HasHelmet:
                break;
            case PlayerState.HasShield:
                break;
            case PlayerState.HasSword:
                break;
            case PlayerState.HasBreastPlate:
                break;
        }

        state = nextState;
    }

    private void StateBehaviour()
    {
        switch (state)
        {
            case PlayerState.None:
                break; 
    
            case PlayerState.Walking:
                break;
            case PlayerState.HasHelmet:
                break;
            case PlayerState.HasShield:
                break;
            case PlayerState.HasSword:
                break;
            case PlayerState.HasBreastPlate:
                break;
        }
    }

    private void PlayerMouvement()
    {
        
        this.transform.Translate(0f,0f,Input.GetAxis("Vertical")*_moveSpeed * Time.fixedDeltaTime);
        this.transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal")*_moveSpeed*10f*Time.fixedDeltaTime, 0f));
    }

    private void HoldTorch()
    {
        holdingTorch = true;
        leftHandOcupied = true;
    }
    private void CanDrop()
    {
        if (Input.GetKey(KeyCode.G) && holdingTorch)
        {
            TorchDrop?.Invoke();
            holdingTorch = false;
            leftHandOcupied = false;
        }
    }

    private void ShieldPlaced()
    {
        if (equipements[3].activeInHierarchy==true)
        {
            equipements[3].SetActive(false);
            leftHandOcupied = false;
        }
    }
    private void BreastPlatePlaced()
    {
        if (equipements[0].activeInHierarchy==true)
        {
            equipements[0].SetActive(false);
        }
    }
    private void HelmetPlaced()
    {
        if (equipements[1].activeInHierarchy==true)
        {
            equipements[1].SetActive(false);
        }
    }
    private void SwordPlaced()
    {
        if (equipements[2].activeInHierarchy==true)
        {
            equipements[2].SetActive(false);
            rightHandOcupied = false;
        }
    }
    
    private void OnDisable()
    {
        Torche.TorchHolding -= HoldTorch;
        Statue.ShieldPlaced -= ShieldPlaced;
        Statue.SwordPlaced -= SwordPlaced;
        Statue.BreastPlatePlaced -= BreastPlatePlaced;
        Statue.HelmetWasPlaced -= HelmetPlaced;
    }
}
