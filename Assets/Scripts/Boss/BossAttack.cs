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
    [SerializeField] float amountAttacks;
    [SerializeField] float angleDif;
    [SerializeField] float speed;
    [SerializeField] int rounds;
    [SerializeField] int shots;
    private int shotCount;
    
    void Start()
    {
        StartCoroutine(Shoot());   
        player = GameObject.FindGameObjectsWithTag("Player");
        playerHealth = player[0].GetComponent<PlayerHealth>();    
    }

    void Update()
    {

    }

    public IEnumerator Shoot()
    {
        for (int a = 0; a < rounds; a++)
        {
            for (int i = 0; i < shots; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab, BossTransform.position, Quaternion.identity);
                Transform enemyTransform = enemy.GetComponent<Transform>();
                enemyTransform.Rotate(0f,0f, randomValue());
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
        return Random.Range(-30f, 30f);
    }
}
