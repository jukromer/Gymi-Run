using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] int CoinCount = 0;
    [SerializeField] GameObject prot_bubble_object;
    [SerializeField] GameObject[] Coins;
    [SerializeField] Text amountCoins;
    [SerializeField] BossController bossController; 

    void Start()
    {
        Coins = GameObject.FindGameObjectsWithTag("Coin");
        if(playerObject.transform.childCount < 1)
        {
            print("Es wurde kein Spieler ausgewählt, gehe über das Main Menu zurück zur Character Selection (P)");
        }
        prot_bubble_object.SetActive(false);
        for(int i = 0; i < Coins.Length; i++)
        {
            Coins[i].SetActive(true);
        }
    }

    void Update()
    {
        
    }

    private void activateShield()
    {
        if(CoinCount == 10)
        {
            prot_bubble_object.SetActive(true);
            CoinCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.CompareTag("Coin"))
        {
            CoinCount++;
            amountCoins.text = CoinCount.ToString();
            activateShield();
            collider.gameObject.SetActive(false);
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


}
