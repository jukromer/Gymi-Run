using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePlayer : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void setCharacterName(string newName)
    {
        Debug.Log(newName);
        PlayerManager.CharacterName = newName;
    }

    public void switchScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
