using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public delegate int Action();

    public static event Action<int> DoorOpenEvent;


    public static void StartDoorEvent(int id)
    {
        DoorOpenEvent?.Invoke(id);
    }
}
