using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreenController : MonoBehaviour
{
    GameObject pauseScreen;
    GameObject DeathScreen;
    public Vector2 RespawnPos;
    public Transform playerSpawn;
    
    void Start()
    {
        pauseScreen = GameObject.Find("PauseScreen");
        pauseScreen.SetActive(false);
        DeathScreen = GameObject.Find("DeathScreen");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !DeathScreen.activeSelf)
        {
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
    }

}
