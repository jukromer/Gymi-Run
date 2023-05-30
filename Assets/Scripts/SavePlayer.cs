using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    public static Transform player;
    public static Animator animator;

    public void setSavePlayer(Transform newPlayer)
    {
        player = newPlayer;
    }

    public Transform getPlayer()
    {
        return player;
    }

    public void setAnimator(Animator newAnimator)
    {
        animator = newAnimator;
    }

    public Animator getAnimnator()
    {
        return animator;
    }
}
