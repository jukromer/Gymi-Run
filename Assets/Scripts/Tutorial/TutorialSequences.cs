using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSequences : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] GameObject [] tables;
    [SerializeField] GameObject Player;
    [SerializeField] Transform playerTransform;
    private Transform playerSpawnPos;
    
    

    void Start()
    {
        playerSpawnPos.position = playerTransform.position;
        UI.SetActive(false);
        tables = GameObject.FindGameObjectsWithTag("Ground");
        for(int i = 4; i < tables.Length; i++)
        {
            deactivateTables(tables[i]);
        }    
    }

    void Update()
    {
        if(playerTransform.position.y <= -6f)
        {
            playerTransform.position = playerSpawnPos.position;
        }
    }

    public void Sequence1()
    {

    }

    public void Sequence2()
    {
        
    }

    public void Sequence3()
    {
        
    }

    public void Sequence4()
    {
        
    }

    public void Sequence5()
    {
        
    }

    private void deactivateTables(GameObject table)
    {
        BoxCollider2D collider = table.GetComponent<BoxCollider2D>();
        collider.enabled = false;
        SpriteRenderer spriteRenderer = table.GetComponent<SpriteRenderer>();
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = 0.5f;
        spriteRenderer.color = spriteColor;
    }

    public void Deactivate(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void Activate(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}
