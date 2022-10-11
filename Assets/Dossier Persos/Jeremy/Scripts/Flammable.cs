using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable : MonoBehaviour
{

    public GameObject helmet_cesar;
    
    public GameObject leftTorch;
    public GameObject centerTorch;
    public GameObject rightTorch;
    [SerializeField] private GameObject _corridorTorch;
    [SerializeField] private GameObject _winIndicator;

    [SerializeField] private bool questionLock = false;

    public GameObject[] torch = new GameObject[3];
    public bool[] rightAnswer = new bool[] {false,true,false};
    public bool[] playerAnswer = new bool[3];


    private void Start()
    {
        torch[0] = leftTorch;
        torch[1] = centerTorch;
        torch[2] = rightTorch;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!questionLock)
        {
            
            //possibilité d'allumer chaque torche de cesar (gauche, milieu, droite)
            if (other.gameObject.CompareTag("Flamable_left")) 
            {
                leftTorch.SetActive(true);
                playerAnswer[0] = true;
            }
        
            if (other.gameObject.CompareTag("Flamable_center")) 
            {
                centerTorch.SetActive(true);
                playerAnswer[1] = true;

            }
        
            if (other.gameObject.CompareTag("Flamable_right"))  
            {
                rightTorch.SetActive(true);
                playerAnswer[2] = true;

            }
        
            HelmetPop();

        }
    }
    
    private void HelmetPop() //fait apparaitre le casque selon certaines conditions
    {
        if (TestAnswer())
        {
            StartCoroutine(DelayBeforeWin(3f));
        }
        else
        { StartCoroutine(DelayBeforeLoose(3f)); }
    }
    
    private bool TestAnswer()
    {
        for (int i = 0; i < playerAnswer.Length; i++)
        {
            if (playerAnswer[i] != rightAnswer[i])
            { return false; }
        }
        return true;
    }
    
    IEnumerator DelayBeforeWin(float duration)
    {
        yield return new WaitForSeconds(duration);
        _corridorTorch.SetActive(true);
        helmet_cesar.SetActive(true);
        StartCoroutine(WinIndication(5f));
        questionLock = true;
    }
    IEnumerator DelayBeforeLoose(float duration)
    {
        yield return new WaitForSeconds(duration);
        leftTorch.SetActive(false);
        centerTorch.SetActive(false);
        rightTorch.SetActive(false);
        for (int i=0;i<playerAnswer.Length;i++)
        {
            playerAnswer[i] = false;
        }
    }
    IEnumerator WinIndication(float duration)
    {
        _winIndicator.SetActive(true);
        yield return new WaitForSeconds(duration);
        _winIndicator.SetActive(false);
    }
}
    
    /*private void OnTriggerEnter(Collider other)
    {
        
        //possibilité d'allumer chaque torche de cesar (gauche, milieu, droite)
        if (other.gameObject.CompareTag("Flamable_left")) 
        {
            leftTorch.SetActive(true);
            leftEnlighted = true;

        }
        
        if (other.gameObject.CompareTag("Flamable_center")) 
        {
            centerTorch.SetActive(true);
            centerEnlighted = true;

        }
        
        if (other.gameObject.CompareTag("Flamable_right"))  
        {
            rightTorch.SetActive(true);
            rightEnlighted = true;

        }
        
        //HelmetPop();

    }
    
    private void HelmetPop() //fait apparaitre le casque selon certaines conditions
    {
        if (leftEnlighted == false && centerEnlighted == true && rightEnlighted == false)   //casque apparait seulement si torche cesar de centre allumées
        {
            StartCoroutine(Delay(1f));
            helmet_cesar.SetActive(true);
        }

        if (leftEnlighted == true && centerEnlighted == true && rightEnlighted == true) // si toutes allumées, toutes s'éteignent (3sec)
        {
            StartCoroutine(Delay(3f));
            leftTorch.SetActive(false);
            centerTorch.SetActive(false);
            rightTorch.SetActive(false);
            leftEnlighted = false;
            centerEnlighted = false;
            rightEnlighted = false;

        }
        
        if (leftEnlighted == true && centerEnlighted == true && rightEnlighted == false) // si gauche et centre allumée = toutes s'éteignent (3sec)
        {
            StartCoroutine(Delay(3f));
            leftTorch.SetActive(false);
            centerTorch.SetActive(false);
            rightTorch.SetActive(false);
            leftEnlighted = false;
            centerEnlighted = false;
            rightEnlighted = false;

        }
        
    }

    IEnumerator Delay(float duration)
    {
        yield return new WaitForSeconds(duration);

    }*/
    

