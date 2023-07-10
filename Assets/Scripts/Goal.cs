using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class Goal : MonoBehaviour
{
    [SerializeField] StopWatch stopwatch;
    [SerializeField] ScoreSaver scoreSaver;
    [SerializeField] GameObject WinScreen;
    [SerializeField] TMP_Text HighScore;
    [SerializeField] TMP_Text Score;


    void Start()
    {
        WinScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stopwatch.PauseTime();
            ScoreSaver.addScore(stopwatch.getTime());
            Time.timeScale = 0f;
            WinScreen.SetActive(true);
            HighScore.text = "Bestzeit: " + ScoreSaver.getHighScore().ToString();
            Score.text = "Zeit: " + ScoreSaver.getScore().ToString();
        }
    }
}
