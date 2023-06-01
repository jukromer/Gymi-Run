using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    GameObject player;
    public Transform BossTransform;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {

    }
}
