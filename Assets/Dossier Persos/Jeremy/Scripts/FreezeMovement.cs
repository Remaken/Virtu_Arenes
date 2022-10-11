using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class FreezeMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 _position; // Création de variable qui stockera la position initiale de notre objet

    // Start is called before the first frame update
    void Start()
    {
        _position = this.transform.position; // Stock la position initiale de notre objet
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = _position; // On réapplique la position initiale à notre object à chaque FRAME pour éviter qu'il bouge en x, y et z
    }
}