using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] int CoinCount = 0;
    [SerializeField] GameObject[] Coins;
    [SerializeField] Text amountCoins;
    [SerializeField] PlayerPowerUps playerPowerUps; 

    void Start()
    {
        Coins = GameObject.FindGameObjectsWithTag("Coin");
        if(playerObject.transform.childCount < 1)
        {
            print("Es wurde kein Spieler ausgewählt, gehe über das Main Menu zurück zur Character Selection (P)");
        }
        
        for(int i = 0; i < Coins.Length; i++)
        {
            Coins[i].SetActive(true);
        }
    }

    void Update()
    {
        
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
        for(int i = 0; i < Coins.Length; i++)
        {
            Coins[i].SetActive(true);
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
    }
}
