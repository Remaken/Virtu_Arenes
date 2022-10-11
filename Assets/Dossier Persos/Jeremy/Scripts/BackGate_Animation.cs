using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BackGate_Animation : MonoBehaviour
{
    [SerializeField] XRSocketInteractor snap;
    public TP_Activation _TPa;
    public Sword_Snap _SwSnap;
    public bool helmetSnapOn = true;
    public GameObject rightFlambeau;
    [SerializeField] private GameObject _backGate;
    [SerializeField] private AudioSource _openingBackGate;



    private void OnEnable()
    {
        snap.selectEntered.AddListener(StartSnap);
        snap.selectExited.AddListener(StopSnap);
        
    }

    private void OnDisable()
    {
        snap.selectEntered.RemoveListener(StartSnap);
        snap.selectExited.RemoveListener(StopSnap);
        
    }
    
    


    private void Start()
    {
        
        helmetSnapOn = false;
        snap.selectEntered.AddListener(StartSnap);
        snap.selectExited.AddListener(StopSnap);

    }

    public void StartSnap(SelectEnterEventArgs args)
    {
        helmetSnapOn = true;
        rightFlambeau.SetActive(true);
        BackGateAnimation();
    }
    
    public void StopSnap(SelectExitEventArgs args)
    {
        helmetSnapOn = false;
        
        if (!helmetSnapOn)
        {
            Debug.Log( " Snap casque terminé");
            
        }
        
    }
    
    public void BackGateAnimation()
    {
        if (snap.socketActive && _SwSnap.snap.socketActive)
        {
            _backGate.GetComponent<Animator>().SetBool("arePlaced", true);
            _TPa.TplanesArena();
            Debug.Log("BackGate dropped down");
            _openingBackGate.Play();
        }
       
       
    }
}
