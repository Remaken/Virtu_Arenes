using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casque : MonoBehaviour
{
    public delegate void HelmetEvent();

    public static event HelmetEvent HelmetWasTaken;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            HelmetWasTaken?.Invoke();
        }

    }
}
