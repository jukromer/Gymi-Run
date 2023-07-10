using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSaver
{
    [SerializeField] static float Score;


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

    public void addScore(float newScore)
    {
        if(Score < newScore)
        {
            Score = newScore;
        }
    }

    public float getScore()
    {
        return Score;
    }
}
