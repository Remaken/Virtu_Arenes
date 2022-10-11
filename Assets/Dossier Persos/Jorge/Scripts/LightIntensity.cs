using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Runtime;
public class LightIntensity : Torche
{
    private Light _lightManager;
    private float minLight;
    private float maxLight;
    private float _randomLight;

    private void Start()
    { 
        _lightManager = gameObject.GetComponent<Light>();
        /*minLight=Random.Range(1.5f,3f);
        maxLight=Random.Range(0.5f,1.5f);*/
        
    }

    private void Update()
    {
        LightIntensityManager();
    }

    private void LightIntensityManager()
    {
        _randomLight=Mathf.Clamp(_randomLight, 1.5f, 3f);
        if (Lumiere.activeSelf == true)
        {
            _lightManager.intensity = _randomLight;
        }
       
       
       /*if (Lumiere.activeSelf)
       {
            StartCoroutine(LightMaxSwitcher());
       }*/
    }

    /*
    IEnumerator LightMaxSwitcher()
    {
        yield return new WaitForSeconds(.2f);
        _lightManager.intensity = maxLight;
        if (_lightManager.intensity >=1.5f)
        {
            _lightManager.intensity = minLight;
        }
        if(_lightManager.intensity<=1.5f)
        {
            _lightManager.intensity = maxLight;
        }
    }
    */

   
    
    
    
    /*
    [Tooltip("External light to flicker; you can leave this null if you attach script to a light")]
    public new Light light;
    [Tooltip("Minimum random light intensity")]
    public float minIntensity = 1f;
    [Tooltip("Maximum random light intensity")]
    public float maxIntensity = 3f;
    [Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
    [Range(1, 50)]
    public int smoothing = 45;

    // Continuous average calculation via FIFO queue
    // Saves us iterating every time we update, we just change by the delta
    Queue<float> smoothQueue;
    float lastSum = 0;


    /// <summary>
    /// Reset the randomness and start again. You usually don't need to call
    /// this, deactivating/reactivating is usually fine but if you want a strict
    /// restart you can do.
    /// </summary>
    public void Reset() {
        smoothQueue.Clear();
        lastSum = 0;
    }

    void Start() {
        smoothQueue = new Queue<float>(smoothing);
        // External or internal light?
        if (light == null) {
            light = GetComponent<Light>();
        }
    }

    void Update() {
        if (light == null)
            return;

        // pop off an item if too big
        while (smoothQueue.Count >= smoothing) {
            lastSum -= smoothQueue.Dequeue();
        }

        // Generate random new item, calculate new average
        float newVal = Random.Range(minIntensity, maxIntensity);
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;

        // Calculate new smoothed average
        light.intensity = lastSum / (float)smoothQueue.Count;
    }
    */
    
    
    
}
