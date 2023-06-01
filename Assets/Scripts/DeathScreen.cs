using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public Vector2 RespawnPos;
    public Transform playerSpawn;
    GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player");
        
    }

    void Update()
    {
        
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Resume()
    {
        playerSpawn.position = RespawnPos;
        GameObject DeathScreen = GameObject.Find("DeathScreen");
        DeathScreen.SetActive(false);  
    }
}
