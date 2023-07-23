using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] GameObject Boss;
    [SerializeField] BossController bossController;
    [SerializeField] Transform playerTransform;
    [SerializeField] bool BossSpawnState;
    [SerializeField] GameObject [] nextPlatforms;
    void Start()
    {
        nextPlatforms = GameObject.FindGameObjectsWithTag("nextPlatform");
        togglePlatforms(false);
        setBossSpawnState(false);
        DestroyBoss();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Player") && getBossSpawnState() == false)
        {
            togglePlatforms(true);
            spawnBoss();
        }
    }

    public void spawnBoss()
    {
        Vector2 SpawnPos = new Vector2(playerTransform.position.x, playerTransform.position.y + 10);
        Instantiate(Boss, SpawnPos, Quaternion.identity);
        setBossSpawnState(true);
    }

    public void setBossSpawnState(bool state)
    {
        BossSpawnState = state;
    }

    public bool getBossSpawnState()
    {
        return BossSpawnState;
    }

    private void toggleCollider(BoxCollider2D boxCollider2D, bool state)
    {
        boxCollider2D.enabled = state;
    }

    private void SetSpriteAlpha(SpriteRenderer spriteRenderer, float alpha)
    {
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = alpha;
        spriteRenderer.color = spriteColor;
    }

    public void togglePlatforms(bool IsAcitve)
    {

        for (int i = 0; i < nextPlatforms.Length; i++)
        {
            if(IsAcitve)
            {
                toggleCollider(nextPlatforms[i].GetComponent<BoxCollider2D>(), true);
                SetSpriteAlpha(nextPlatforms[i].GetComponent<SpriteRenderer>(), 1f);
            }
            else
            {
                toggleCollider(nextPlatforms[i].GetComponent<BoxCollider2D>(), false);
                SetSpriteAlpha(nextPlatforms[i].GetComponent<SpriteRenderer>(), 0.5f); 
            }  
        } 
    }

    public void DestroyBoss()
    {
        if (getBossSpawnState())
        {
            GameObject [] Boss = GameObject.FindGameObjectsWithTag("Boss");
            for(int i = 0; i < Boss.Length; i++)
            {
                Destroy(Boss[i]);
            }
        }
    }

}

