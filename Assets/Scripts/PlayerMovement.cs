using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed; //7 war gut
    [SerializeField] private float jumpHeight; //12 war gut
    public float airspeed = 1.0F; //0.5
    private bool onGround = true;
    private int jumpCount = 0;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 3;
        body.drag = 0;
        body.angularDrag = 0;
    }

    private void Update()
    {
        {
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * (speed * airspeed), body.velocity.y);
            
            if (onGround && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }   
    }

    private void Jump()
    {
        if(jumpCount == 0)
            {
                body.velocity = new Vector2(body.velocity.x, jumpHeight);
                jumpCount++;
                airspeed = 1.2F;
            }
            else
            {
                onGround = false;
                body.velocity = new Vector2(body.velocity.x, jumpHeight);
                airspeed = 0.8F;
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            jumpCount = 0;
            airspeed = 1F;
        }
    }
}