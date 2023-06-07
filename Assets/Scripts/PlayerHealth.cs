using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public PlayerUI playerUI;
    public Transform playerPos;
    [SerializeField] DeathScreenController DeathScreenController;
    [SerializeField] BossMovement bossMovement;
    
    
    void Start()
    {
        Time.timeScale = 1f;
        currentHealth = maxHealth;        
    }

    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        if(currentHealth - amount <= 0)
        {
            Time.timeScale = 0f;
            bossMovement.setBossSpawnState(false);
            playerUI.amountHealth.text = "0";
            DeathScreenController.toggleDeathScreen(true);
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
