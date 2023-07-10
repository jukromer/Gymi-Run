using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] StopWatch stopwatch;
    [SerializeField] ScoreSaver scoreSaver;

    void Start()
    {
        scoreSaver = new ScoreSaver(0);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stopwatch.PauseTime();
            scoreSaver.addScore(stopwatch.getTime());
        }
    }
}
