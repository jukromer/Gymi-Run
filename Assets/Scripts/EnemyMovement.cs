using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform enemyTransform;
    [SerializeField] float speed;
    [SerializeField] GameObject enemy;
    private float randomRotation;

    void Start()
    {

    }

 
    void Update()
    {
        Fly();
    }

    public void Fly()
    {
        enemyTransform.position = new Vector2(enemyTransform.position.x - speed * Time.deltaTime, enemyTransform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(this);
        }
    }

    private float randomValue()
    {
        return Random.Range(-10f, 10f);
    }
}

