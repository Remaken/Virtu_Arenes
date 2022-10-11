using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject TexteDrop;


    private void Start()
    {
        StartCoroutine(TextTimer());
    }

    IEnumerator TextTimer()
    {
        yield return new WaitForSeconds(20f);
        Destroy(TexteDrop);
    }
}
