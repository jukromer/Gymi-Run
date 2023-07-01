using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] GameObject Boss;
    [SerializeField] BossController bossController;
    [SerializeField] Transform playerTransform;
    void Start()
    {
        
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
            bossController.setSpawnState(true);
        }
    }

    public void toggleBossState(bool state)
    {
        Boss.SetActive(state);
    }
}

