using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int Damage;
    public PlayerHealth playerHealth;
    private GameObject [] player;
    // Start is called before the first frame update
    void Start()
    {
        if(playerHealth == null)
        {
            player = GameObject.FindGameObjectsWithTag("Player");
            playerHealth = player[0].GetComponent<PlayerHealth>();
        }
    }

    // Update is called once per frame
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
}
