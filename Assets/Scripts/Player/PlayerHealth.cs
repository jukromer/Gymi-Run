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
    [SerializeField] GameObject[] Hearts;
    [SerializeField] GameObject DamageVignette;
    
    
    void Start()
    {
        DamageVignette.SetActive(false);
        Hearts = GameObject.FindGameObjectsWithTag("Heart");
        Time.timeScale = 1f;
        currentHealth = maxHealth; 
        print(Hearts.Length);       
    }

    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        if(currentHealth - amount <= 0)
        {
            currentHealth = 0;
            Time.timeScale = 0f;
            bossMovement.setBossSpawnState(false);
            DeathScreenController.toggleDeathScreen(true);
        }
        else if(currentHealth - amount > 0)
        {
            DamageVignette.SetActive(true);
            Hearts[currentHealth - 1].SetActive(false);
            currentHealth = currentHealth - amount;
        }
        Invoke("turnVignetteOff", 0.15f);
    }

    public void Heal(int amount)
    {
        if(currentHealth + amount > maxHealth)
        {
            currentHealth = maxHealth;
            for(int i = 0; i < Hearts.Length; i++)
            {
                Hearts[i].SetActive(true);
            }
        }
        else
        {
            currentHealth = currentHealth + amount;
        }
    }

    private void turnVignetteOff()
    {
        DamageVignette.SetActive(false);
    }
}
