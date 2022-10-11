using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonlaunch : MonoBehaviour
{

    public void LaunchApplication()
    {
        Debug.Log("Game Launched");
        SceneManager.LoadScene("Virtu Arene");
    }
    
    
    
}
