using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public PlayerUI playerUI;
    //public DeathScreen deathScreen;
    public Transform playerPos;
    GameObject DeathScreen;
    
    
    void Start()
    {
        currentHealth = maxHealth; 
        DeathScreen = GameObject.Find("DeathScreen");
        DeathScreen.SetActive(false);       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        if(currentHealth - amount <= 0)
        {
            playerUI.amountHealth.text = "0";
            
            GameObject Player = GameObject.Find("Player");

            DeathScreen.SetActive(true);
            //deathScreen.RespawnPos = new Vector2(playerPos.position.x, playerPos.position.y + 10);
        }
        else
        {
            currentHealth = currentHealth - amount;
        }

    }

    public void Heal(int amount)
    {
        if(currentHealth + amount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = currentHealth + amount;
        }
    }
}
