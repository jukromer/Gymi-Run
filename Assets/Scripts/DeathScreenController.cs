using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class DeathScreenController : MonoBehaviour
{
    public Vector2 RespawnPos;
    public Transform playerSpawn;
    [SerializeField] GameObject DeathScreen;
    public bool DeathScreenOn;
    [SerializeField] BossTrigger bossTrigger;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] PlayerPowerUps playerPowerUps;

    void Start()
    {
        //playerMovement.body.constraints = RigidbodyConstraints2D.None;
        toggleDeathScreen(false);
    }

    void Update()
    {
        
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Respawn()
    {
        playerHealth.Heal(4);
        Time.timeScale = 1f;
        print("Respawn");
        playerSpawn.position = RespawnPos;
        toggleDeathScreen(false);  
        playerController.resetCoins();
        playerPowerUps.toggleProtBubble(false);
        playerPowerUps.togglePowerUps(false);
    }

    public void toggleDeathScreen(bool state)
    {
        DeathScreen.SetActive(state);
        DeathScreenOn = state;
    }
}
