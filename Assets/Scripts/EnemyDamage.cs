using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int Damage;
    public PlayerHealth playerHealth;
    private GameObject [] player;
    [SerializeField] int defaultDamage;
    
    void Start()
    {
        Damage = defaultDamage;
        if(playerHealth == null)
        {
            player = GameObject.FindGameObjectsWithTag("Player");
            playerHealth = player[0].GetComponent<PlayerHealth>();
        }
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerHealth.Damage(Damage);
        }    
    }

    public void setEnemyDamage(int newDamage)
    {
        Damage = newDamage;
    }

    public void setDeafaultEnemyDamage()
    {
        Damage = defaultDamage;
    }
}
