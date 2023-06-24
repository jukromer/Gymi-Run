using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] bool isSpawned;
    [SerializeField] BossAttack bossAttack;
    [SerializeField] BossMovement bossMovement;

    void Start()
    {

    }

    void Update()
    {
        if(getSpawnState())
        {
            bossAttack.Shoot();
        }
    }

    public bool getSpawnState()
    {
        return isSpawned;
    }

    public void setSpawnState(bool state)
    {
        isSpawned = state;
    }
}
