using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private Transform player;
    [SerializeField] private float speed; //7 war gut
    [SerializeField] private float jumpHeight; //12 war gut
    [SerializeField] private LayerMask groundLayer;
    public float airspeed = 1.0F; //0.5
    private int jumpCount = 0;
    private BoxCollider2D boxCollider;
    

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = 3;
        body.drag = 0;
        body.angularDrag = 0;
        boxCollider = GetComponent<BoxCollider2D>();
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

        if (Input.GetKeyDown(KeyCode.Space))
        {   
            Jump();
        } 
        
        
    }

    private void Jump()
    {   
        
        
        if(jumpCount == 0 && isGrounded())
            {
                body.velocity = new Vector2(body.velocity.x, jumpHeight);
                jumpCount++;
                airspeed = 1.2F;
            }            
        else if(jumpCount == 1)
            {
                body.velocity = new Vector2(body.velocity.x, jumpHeight);
                airspeed = 0.8F;
                jumpCount = 0; 
            }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }


    private bool isGrounded() 
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    


    
}
