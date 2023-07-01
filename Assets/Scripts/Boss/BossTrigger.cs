using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] GameObject Boss;
    [SerializeField] BossController bossController;
    [SerializeField] Transform playerTransform;
    [SerializeField] bool BossSpawnState;
    void Start()
    {
        setBossSpawnState(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Vector2 SpawnPos = new Vector2(playerTransform.position.x, playerTransform.position.y + 10);
            Instantiate(Boss, SpawnPos, Quaternion.identity);
            setBossSpawnState(true);
        }
    }

    public void setBossSpawnState(bool state)
    {
        BossSpawnState = state;
    }

    public bool getBossSpawnState()
    {
        return BossSpawnState;
    }
}

