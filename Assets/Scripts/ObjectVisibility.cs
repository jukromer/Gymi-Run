using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVisibility : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        collision.gameObject.SetActive(true);
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        collision.gameObject.SetActive(false);
    }
}
