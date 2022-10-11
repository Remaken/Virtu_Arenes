using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public delegate void TriggerEvent();

    public static event TriggerEvent ShieldWasTaken;
}
