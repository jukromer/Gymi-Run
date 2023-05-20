using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private Transform player;
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
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * (speed * airspeed), body.velocity.y);
        
        //Flip Player accoring to direction
        if(horizontalInput > 0.01F)
        {
            transform.localScale = Vector3.one;
        }
        else if(horizontalInput < -0.01F)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
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
