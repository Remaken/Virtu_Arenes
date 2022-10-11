using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bouclier : MonoBehaviour
{
    public delegate void ShieldEvent();

    public static event ShieldEvent ShieldWasTaken;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            ShieldWasTaken?.Invoke();
        }

    }
}
