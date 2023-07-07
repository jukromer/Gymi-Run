using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using TMPro;

public class StopWatch : MonoBehaviour
{
    [SerializeField] TMP_Text time;
    private Stopwatch stopwatch;
    private float currentTime;

    void Start()
    {
        stopwatch = new Stopwatch();   
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            StartTime(); 
        }
        if (stopwatch != null)
        {
            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            float elapsedSeconds = elapsedMilliseconds / 1000f;
            currentTime = elapsedSeconds;
            time.text = elapsedSeconds.ToString();
        }
    }

    public void ResetTime()
    {
        stopwatch.Reset();
    }

    public void PauseTime()
    {
        stopwatch.Stop();
    }

    public void StartTime()
    {
        stopwatch.Start();
    }

    public float getTime()
    {
        return currentTime;
    }
}
