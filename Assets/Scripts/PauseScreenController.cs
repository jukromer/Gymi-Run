using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class PauseScreenController : MonoBehaviour
{
    GameObject pauseScreen;
    GameObject DeathScreen;
    public Vector2 RespawnPos;
    public Transform playerSpawn;
    public PlayerHealth playerHealth;
    
    void Start()
    {
        Time.timeScale = 1f;
        pauseScreen = GameObject.Find("PauseScreen");
        pauseScreen.SetActive(false);
        DeathScreen = GameObject.Find("DeathScreen");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !playerHealth.DeathScreenOn)
        {
            Time.timeScale = 0f;
            RespawnPos = playerSpawn.position;
            pauseScreen.SetActive(true);
        }      
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Resume()
    {
        playerSpawn.position = RespawnPos;
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

}
