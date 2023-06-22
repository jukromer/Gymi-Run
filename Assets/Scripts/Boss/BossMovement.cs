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
    private Rigidbody2D bossBody;
    bool movingUp;
    float topEdge;
    float bottomEdge;
    //[SerializeField] bool isSpawned;
    [SerializeField] float speed;
    //[SerializeField] float movementDistance;
    private Vector2 bossRestingPos;
    [SerializeField] BossController bossController;

    void Start()
    {
        topEdge = player.position.y + movementDistance();
        bottomEdge = player.position.y - movementDistance();
        bossRestingPos = boss.position;
        bossBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(bossController.getSpawnState())
        {
            BossMovingSequence();
        }
        else
        {
            boss.position = bossRestingPos;
        }
    }

    void BossMovingSequence()
    {
        if(movingUp)
        {
            if (boss.position.y < topEdge)
            {
                boss.position = new Vector2(player.position.x + 10, boss.position.y + speed * Time.deltaTime);
            }
            else
            {
                topEdge = player.position.y + movementDistance();
                movingUp = false;
            }
        }
        else
        {
            if (boss.position.y > bottomEdge)
            {
                boss.position = new Vector2(player.position.x + 10, boss.position.y - speed * Time.deltaTime);   
            }
            else
            {
                bottomEdge = player.position.y - movementDistance();
                movingUp = true;
            }
        }
    }

    float movementDistance()
    {
        float randomValue = Random.Range(1.0f, 3.0f);
        return randomValue;
    }

    public void resetBossPos()
    {
        boss.position = bossRestingPos;
        bossController.setSpawnState(false);
    }
}
