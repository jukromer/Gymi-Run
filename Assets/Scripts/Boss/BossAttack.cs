using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] PlayerHealth playerHealth;
    bool isAttacking = false;
    [SerializeField] float shootInterval;
    [SerializeField] Transform BossTransform;
    [SerializeField] float amountAttacks;
    [SerializeField] float angleDif;
    
    void Start()
    {
        StartCoroutine(Shoot());       
    }

    void Update()
    {

    }

    public IEnumerator Shoot()
    {
        GameObject enemy = Instantiate(enemyPrefab, BossTransform.position, Quaternion.identity);
        Transform enemyTransform = GetComponent<Transform>();
        for(float i = 0; i < amountAttacks; i++)
        {
            enemyTransform.position = shootingAngle(angleDif * i);
        }
        yield return new WaitForSeconds(shootInterval);
    }

    public void setAttackState(bool state)
    {
        isAttacking = state;
    }

    private Vector2 shootingAngle(float Angle)
    {
        return Quaternion.Euler(0f, 0f, Angle) * Vector2.right;
    }
}
