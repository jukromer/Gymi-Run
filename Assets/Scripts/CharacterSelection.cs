using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public SavePlayer savePlayer;

    void Start()
    {

    }

    
    void Update()
    {
        
    }

    public void GetCharacter(Transform player, Animator animator)
    {
        savePlayer.setSavePlayer(player);
        savePlayer.setAnimator(animator);
        SceneManager.LoadScene("Level1");     
    }
}
