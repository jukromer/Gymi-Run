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
    [SerializeField] bool isSpawned;
    [SerializeField] float speed;
    [SerializeField] float movementDistance;
    private Vector2 bossRestingPos;

    void Start()
    {
        bossRestingPos = boss.position;
        topEdge = player.position.y + movementDistance;
        bottomEdge = player.position.y - movementDistance;
        bossBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isSpawned)
        {
            BossSequence();
        }
    }

    void BossSequence()
    {
        boss.position = new Vector2(player.position.x + 10, player.position.y + (speed * movementDirection()) * Time.deltaTime);
        //bossBody.velocity = new Vector2(boss.position.x, player.position.y + (speed * movementDirection()) * Time.deltaTime);
    }

    float movementDirection()
    {
        
        float randomValue = Random.Range(0.0f, 2.0f);
        if (randomValue < 1)
        {
            movingUp = false;
            Wait(1);
            return -1f;
        }
        else
        {
            movingUp = true;
            Wait(1);
            return 1f;
        }
    }

    public void setBossSpawnState(bool state)
    {
        isSpawned = state;
    }

    private IEnumerator WaitForTime(int time)
    {
        yield return new WaitForSeconds(time);
    }

    private void Wait(int seconds)
    {
        StartCoroutine(WaitForTime(seconds));
    }

    public void resetBossPos()
    {
        boss.position = bossRestingPos;
        isSpawned = false;
    }
}
