using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epee : MonoBehaviour
{  
    public delegate void SwordEvent();

    public static event SwordEvent SwordWasTaken;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SwordWasTaken?.Invoke();
        }

    }
}
