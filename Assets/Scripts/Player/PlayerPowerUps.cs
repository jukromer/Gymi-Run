using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    [SerializeField] GameObject prot_bubble;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] bool PowerUpsActive;
    [SerializeField] PlayerController playerController;
    void Start()
    {
        togglePowerUps(false);
        toggleProtBubble(false);
    }

    void Update()
    {
        if(PowerUpsActive && Input.GetKeyDown(KeyCode.B))
        {
            toggleProtBubble(true);
            togglePowerUps(false);
            playerController.resetCoins();
        }
        if(PowerUpsActive && Input.GetKeyDown(KeyCode.H))
        {
            addHealth();
            togglePowerUps(false);
            playerController.resetCoins();
        }
    }

    public void togglePowerUps(bool state)
    {
        PowerUpsActive = state;
    }

    public void toggleProtBubble(bool state)
    {
        if (state == true)
        {
            prot_bubble.SetActive(true);
            Invoke("deactivateShield", 10f);
        }
        else
        {
            prot_bubble.SetActive(false);
        }
    }

    private void addHealth()
    {
        playerHealth.Heal(1);
    }

    private void deactivateShield()
    {
        prot_bubble.SetActive(false);
    }
}
