using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerAnimator : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        PlayerManager.CharacterAnimator = animator;
    }
}
