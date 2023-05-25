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
    public Animator animator;
    

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
        
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        //Flip Player accoring to direction
        if(horizontalInput > 0.01F)
        {
            transform.localScale = Vector3.one;
        }
        else if(horizontalInput < -0.01F)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        if(isGrounded())
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsDoubleJumping", false);
            jumpCount = 0;
        } 
        
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            if(jumpCount == 0)
            {
                animator.SetBool("IsJumping", true);
                Jump();
            }
            else
            {
                animator.SetBool("IsDoubleJumping", true);
                DoubleJump();
            }
        }
        
    }

    private void Jump()
    {     
        
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        jumpCount++;
        airspeed = 1.2F;          
    }

    private void DoubleJump()
    { 
        
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        airspeed = 0.8F;
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
