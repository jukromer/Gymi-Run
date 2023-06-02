using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreenController : MonoBehaviour
{
    public Vector2 RespawnPos;
    public Transform playerSpawn;
    [SerializeField] GameObject DeathScreen;
    public bool DeathScreenOn;

    void Start()
    {
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
        print("Respawn");
        playerSpawn.position = RespawnPos;
        toggleDeathScreen(false);  
    }

    public void toggleDeathScreen(bool state)
    {
        DeathScreen.SetActive(state);
        DeathScreenOn = state;
    }
}
