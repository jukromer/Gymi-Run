using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private bool isSpawned;

    void Start()
    {
        
    }

    void Update()
    {
        
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
