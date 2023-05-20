using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{  
    public Text amountHealth;
    public PlayerHealth playerHealth;
    
    
    void Start()
    {
        setHealth();       
    }

    void Update()
    {
        setHealth();
    }

    public void setHealth()
    {
        amountHealth.text = playerHealth.currentHealth.ToString();
    }

}
