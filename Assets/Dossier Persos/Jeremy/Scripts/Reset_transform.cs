using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_transform : MonoBehaviour
{
    [SerializeField] private Vector3[] objectPosition;
    public GameObject[] objetToReset;
    

    private void Start()
    {
        for (int i = 0; i < objetToReset.Length; i++)
        {
            objectPosition[i] = objetToReset[i].GetComponent<Transform>().position;
        }
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision avec : " + other.name);
        
        
        if (other.gameObject.CompareTag("Epee"))
        {
            other.gameObject.transform.position = objectPosition[0];
        } 
        
        if (other.gameObject.CompareTag("Casque"))
        {
            other.gameObject.transform.position = objectPosition[1];
        } 
        
        if (other.gameObject.CompareTag("Torche"))
        {
            other.gameObject.transform.position = objectPosition[2];
        } 
        
    }
    
}
