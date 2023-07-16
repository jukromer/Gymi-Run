using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int Damage;
    public PlayerHealth playerHealth;
    private GameObject [] player;
    [SerializeField] int defaultDamage;
    [SerializeField] bool EffectByChance;
    
    void Start()
    {
        Damage = defaultDamage;
        if(playerHealth == null)
        {
            player = GameObject.FindGameObjectsWithTag("Player");
            playerHealth = player[0].GetComponent<PlayerHealth>();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (EffectByChance)
            {
                if (Effect())
                {
                    playerHealth.Heal(1);
                }
                else
                {
                    playerHealth.Damage(Damage);
                }
            }
            else
            {
               playerHealth.Damage(Damage); 
            }
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

    private bool Effect()
    {
        int randomNumber = RandomNumber();
        print(randomNumber);
        if(randomNumber > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int RandomNumber()
    {
        int randomValue = (int) Random.Range(-2 ,2);
        return randomValue;
    }
}
