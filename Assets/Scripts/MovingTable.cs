using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTable : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    [SerializeField] bool horizontal;
    bool movingDown;
    float topEdge;
    float bottomEdge;

    void Start()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;

        bottomEdge = transform.position.y - movementDistance;
        topEdge = transform.position.y + movementDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if(horizontal)
        {
            if(movingLeft)
            {
                if(transform.position.x > leftEdge)
                {
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z); 
                }
                else
                    movingLeft = false;
            }
            else
            {
                if(transform.position.x < rightEdge)
                {
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z); 
                }
                else
                    movingLeft = true;
            }
        }
        else
        {
            if(movingDown)
            {
                if(transform.position.y > bottomEdge)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z); 
                }
                else
                    movingDown = false;
            }
            else
            {
                if(transform.position.y < topEdge)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z); 
                }
                else
                    movingDown = true;
            }  
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        collision.transform.SetParent(transform);
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {   
        collision.transform.SetParent(null);
    }
}
