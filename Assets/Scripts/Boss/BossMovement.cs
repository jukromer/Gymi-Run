using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector2 playerPos;
    [SerializeField] Animator animator;
    public Transform boss;
    bool movingUp;
    float topEdge;
    float bottomEdge;
    bool isSpawned;
    [SerializeField] float speed;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("BossTrigger"))
        {
            isSpawned = true;
            BossSequence();
        }
    }

    void BossSequence()
    {
        while (isSpawned)
        {
            boss.position = new Vector2(player.position.x + 10, player.position.y + (speed * movementDirection()) * Time.deltaTime);
            Thread.Sleep(1000);  
        }
    }

    float movementDirection()
    {
        float randomValue;
        randomValue = Random.Range(0.0f, 2.0f);
        if (randomValue < 1)
        {
            movingUp = false;
            return -1f;
        }
        else
        {
            movingUp = true;
            return 1f;
        }
    }
}
