using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prot_Bubble : MonoBehaviour
{
    private GameObject enemy;
    private EnemyDamage enemyDamage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.gameObject;
            enemyDamage = enemy.GetComponent<EnemyDamage>();
            enemyDamage.setEnemyDamage(0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject == enemy)
        {
            enemyDamage.setDeafaultEnemyDamage();
        }
    }
}
