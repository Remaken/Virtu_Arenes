using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plastron : MonoBehaviour
{
    public delegate void BreastPlateEvent();

    public static event BreastPlateEvent BreastPlateWasTaken;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            BreastPlateWasTaken?.Invoke();
        }

    }
}

