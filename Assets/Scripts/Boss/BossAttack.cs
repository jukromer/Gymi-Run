using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] PlayerHealth playerHealth;
    private GameObject [] player;
    bool isAttacking = false;
    [SerializeField] float roundInterval;
    [SerializeField] float shootInterval;
    [SerializeField] Transform BossTransform;
    [SerializeField] float speed;
    [SerializeField] int rounds;
    [SerializeField] int shots;
    private int shotCount;
    [SerializeField] BossTrigger bossTrigger;
    private GameObject [] trigger;
    
    void Start()
    {
        trigger = GameObject.FindGameObjectsWithTag("BossTrigger");
        bossTrigger = trigger[0].GetComponent<BossTrigger>();
        StartCoroutine(Shoot());   
        player = GameObject.FindGameObjectsWithTag("Player");
        playerHealth = player[0].GetComponent<PlayerHealth>();    
    }

    void Update()
    {

    }

    public IEnumerator Shoot()
    {
        while (bossTrigger.getBossSpawnState())
        {
            for (int i = 0; i < shots; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab, BossTransform.position, Quaternion.identity);
                Transform enemyTransform = enemy.GetComponent<Transform>();
                enemyTransform.Rotate(0f,0f, randomValue());
                print("shot" + i);
                yield return new WaitForSeconds(shootInterval);
            }
            yield return new WaitForSeconds(roundInterval);
        }
    }

    public void setAttackState(bool state)
    {
        isAttacking = state;
    }

    private Vector2 shootingAngle(float Angle)
    {
        return Quaternion.Euler(0f, 0f, Angle) * Vector2.right;
    }

    private float randomValue()
    {
        return Random.Range(-12f, 12f);
    }
}
