using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class PauseScreenController : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    [SerializeField] DeathScreenController DeathScreenController;
    public Vector2 RespawnPos;
    public Transform playerSpawn;
    public bool PauseScreenOn;
    
    void Start()
    {
        Time.timeScale = 1f;
        togglePauseScreen(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !DeathScreenController.DeathScreenOn)
        {
            RespawnPos = playerSpawn.position;
            Time.timeScale = 0f;
            togglePauseScreen(true);
        }      
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Resume()
    {
        playerSpawn.position = RespawnPos;
        togglePauseScreen(false);
        Time.timeScale = 1f;
    }

    public void togglePauseScreen(bool state)
    {
        pauseScreen.SetActive(state);
        PauseScreenOn = state;
    }
}
