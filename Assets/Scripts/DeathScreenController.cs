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
    [SerializeField] BossMovement bossMovement;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerController playerController;

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
        Time.timeScale = 1f;
        //playerMovement.body.constraints = RigidbodyConstraints2D.None;
        print("Respawn");
        bossMovement.resetBossPos();
        playerSpawn.position = RespawnPos;
        toggleDeathScreen(false);  
        playerController.resetCoins();
    }

    public void toggleDeathScreen(bool state)
    {
        //playerMovement.body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        DeathScreen.SetActive(state);
        DeathScreenOn = state;

    }
}
