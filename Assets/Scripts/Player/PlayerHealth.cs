using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public PlayerUI playerUI;
    public Transform playerPos;
    [SerializeField] DeathScreenController DeathScreenController;
    [SerializeField] BossController bossController;
    [SerializeField] GameObject[] Hearts;
    [SerializeField] GameObject DamageVignette;
    private GameObject [] Boss;
    [SerializeField] Animator heartAnimator;
    [SerializeField] StopWatch stopwatch;
    [SerializeField] TMP_Text RunTime;
    [SerializeField] PlayerPowerUps powerUps;
    [SerializeField] private AudioSource damageSound;
    
    void Start()
    {
        DamageVignette.SetActive(false);
        //Hearts = GameObject.FindGameObjectsWithTag("Heart");
        Time.timeScale = 1f;
        currentHealth = maxHealth; 
        heartAnimator.SetBool("IsBeating", false);       
    }

    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        if (amount > 0)
        {
            damageSound.Play();
            if(currentHealth - amount <= 0)
            {
                
                currentHealth = 0;
                Time.timeScale = 0f;
                Boss = GameObject.FindGameObjectsWithTag("Boss");
                stopwatch.PauseTime();
                RunTime.text = "Time: " + stopwatch.getTime().ToString();
                powerUps.toggleHealAvailable(false);
                if (Boss.Length > 0)
                {
                    Destroy(Boss[0]);
                }
                DeathScreenController.toggleDeathScreen(true);
            }
            else if(currentHealth - amount > 0)
            {
                DamageVignette.SetActive(true);
                Hearts[currentHealth - 1].SetActive(false);
                currentHealth = currentHealth - amount;
            }
            Invoke("turnVignetteOff", 0.15f);
            if(currentHealth == 1)
            {
                heartAnimator.SetBool("IsBeating", true);
                DamageVignette.SetActive(true);
            }
            else
            {
                heartAnimator.SetBool("IsBeating", false);
            }
        }
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
            Hearts[currentHealth -1].SetActive(true);
        }
        heartAnimator.SetBool("IsBeating", false);
        DamageVignette.SetActive(false);
    }

    private void turnVignetteOff()
    {
        DamageVignette.SetActive(false);
    }
}
