using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSaver
{
    [SerializeField] static float Score;
    [SerializeField] static float HighScore;


    public ScoreSaver(float newScore)
    {
        Score = newScore;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public static void addScore(float newScore)
    {
        if(newScore > PlayerPrefs.GetFloat("HighScore"))
        {
            Score = newScore;
            PlayerPrefs.SetFloat("Highscore", newScore);
            PlayerPrefs.Save();
        }
        else
        {
            Score = newScore;
        }
    }

    public static float getScore()
    {
        return Score;
    }

    public static float getHighScore()
    {
        return PlayerPrefs.GetFloat("Highscore");
    }
}
