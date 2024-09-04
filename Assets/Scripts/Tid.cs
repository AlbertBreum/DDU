using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class Tid : MonoBehaviour
{
    private float TimeSinceStart = 0f;
    bool TimerIsRunning = true;
    private float TimeElapsed = 0f;
    // Update is called once per frame
    void Update()
    {
        if(TimerIsRunning == true)
        {
            TimeElapsed = TimeSinceStart += Time.deltaTime;
            //Debug.Log(TimeElapsed % 10);
        }
    }
}
