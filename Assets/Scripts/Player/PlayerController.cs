using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] int CoinCount = 0;
    [SerializeField] Text amountCoins;
    [SerializeField] PlayerPowerUps playerPowerUps;
    [SerializeField] CoinGenerator coinGenerator;
    [SerializeField] float HighScore;
    [SerializeField] float Score; 

    void Start()
    {
        if(playerObject.transform.childCount < 1)
        {
            print("Es wurde kein Spieler ausgewählt, gehe über das Main Menu zurück zur Character Selection (P)");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.CompareTag("Coin"))
        {
            CoinCount++;
            amountCoins.text = CoinCount.ToString();
            collider.gameObject.SetActive(false);
            if(CoinCount == 10)
            {
                playerPowerUps.togglePowerUps(true);
            }
        }
    }

    public void resetCoins()
    {
        if (coinGenerator != null)
        {
            coinGenerator.deleteCoins();
            coinGenerator.spawnCoins();
            CoinCount = 0;
            amountCoins.text = CoinCount.ToString();
        }
    }

    public int getPlayerCoinCount()
    {
        return CoinCount;
    }

    public void setPlayerCoinCount(int amount)
    {
        CoinCount = amount;
        amountCoins.text = CoinCount.ToString();
        if(CoinCount == 10)
        {
            playerPowerUps.togglePowerUps(true);
        }
    }

    public void SaveScore(float newScore)
    {
        if(newScore < getHighScore() || getHighScore() == 0)
        {
            HighScore = newScore;
            Score = newScore;
            PlayerPrefs.SetFloat("Highscore", HighScore);
            PlayerPrefs.Save();
        }
        else
        {
            Score = newScore;
        }
    }

    public float getHighScore()
    {
        return PlayerPrefs.GetFloat("Highscore");
    }

    public float getScore()
    {
        return Score;
    }

    public void DeleteScore()
    {
        PlayerPrefs.DeleteKey("Highscore");
    }
}
