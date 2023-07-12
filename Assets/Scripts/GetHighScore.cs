using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetHighScore : MonoBehaviour
{
    [SerializeField] TMP_Text HighScore;
    void Start()
    {
        HighScore.text = "Bestzeit " + PlayerPrefs.GetFloat("Highscore").ToString();
    }
}
