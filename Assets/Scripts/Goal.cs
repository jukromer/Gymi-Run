using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class Goal : MonoBehaviour
{
    [SerializeField] StopWatch stopwatch;
    [SerializeField] GameObject WinScreen;
    [SerializeField] TMP_Text HighScore;
    [SerializeField] TMP_Text Score;
    [SerializeField] PlayerController playerController;
    [SerializeField] BossTrigger bossTrigger;


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
            bossTrigger.setBossSpawnState(false);
            bossTrigger.DestroyBoss();
            stopwatch.PauseTime();
            playerController.SaveScore(stopwatch.getTime());
            Time.timeScale = 0f;
            WinScreen.SetActive(true);
            HighScore.text = "Bestzeit: " + playerController.getHighScore().ToString();
            Score.text = "Zeit: " + playerController.getScore().ToString();
        }
    }
}
