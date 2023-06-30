using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] GameObject Boss;
    [SerializeField] BossController bossController;
    void Start()
    {
        toggleBossState(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            toggleBossState(true);
            bossController.setSpawnState(true);
        }
    }

    public void toggleBossState(bool state)
    {
        Boss.SetActive(state);
    }
}

