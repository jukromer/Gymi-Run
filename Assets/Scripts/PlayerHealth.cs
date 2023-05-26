using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public PlayerUI playerUI;
    public Transform playerSpawn;
    private Vector2 SpawnPos;
    
    void Start()
    {
        currentHealth = maxHealth;
        SpawnPos = playerSpawn.position;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        if(currentHealth - amount <= 0)
        {
            playerSpawn.position = SpawnPos;
            playerUI.amountHealth.text = "0";
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
