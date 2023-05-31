using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static string CharacterName;
    public static Animator CharacterAnimator;

    private void Start() 
    {
        Debug.Log(CharacterName); 
        Debug.Log(CharacterAnimator);   
    }
}
