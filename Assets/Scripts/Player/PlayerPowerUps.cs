using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    [SerializeField] GameObject prot_bubble;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] bool PowerUpsActive;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject HealAvailable;
    void Start()
    {
        togglePowerUps(false);
        toggleProtBubble(false);
        toggleHealAvailable(false);
    }

    void Update()
    {
        if(PowerUpsActive)
        {
            toggleHealAvailable(true);
            if(Input.GetKeyDown(KeyCode.B))
            {
                toggleProtBubble(true);
                togglePowerUps(false);
                playerController.setPlayerCoinCount(playerController.getPlayerCoinCount() - 10);
            }
            if(Input.GetKeyDown(KeyCode.H))
            {
                addHealth();
                togglePowerUps(false);
                playerController.setPlayerCoinCount(playerController.getPlayerCoinCount() - 10);
            }
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
            toggleHealAvailable(false);
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
        toggleHealAvailable(false);
    }

    private void deactivateShield()
    {
        prot_bubble.SetActive(false);
    }

    public void toggleHealAvailable(bool state)
    {
        HealAvailable.SetActive(state);
    }
}
