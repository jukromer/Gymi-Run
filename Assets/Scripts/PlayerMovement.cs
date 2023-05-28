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
    public int jumpCount = 0;
    private BoxCollider2D boxCollider;
    public Animator animator;
    public float fallGravityScale = 4f;
    public float gravityScale = 3f;
    public  bool IsGrounded = true;
    

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = gravityScale;
        body.drag = 0;
        body.angularDrag = 0;
        boxCollider = GetComponent<BoxCollider2D>();
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
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


        if (Input.GetKeyDown(KeyCode.Space))
        {   
            if(IsGrounded && jumpCount == 0)
            {   IsGrounded = false;           
                jumpCount++;
                Jump();  
            }
            else if(jumpCount == 1)
            {   
                DoubleJump();
            }
        }   
    }

    private void FixedUpdate() 
    {
        if(body.velocity.y < 0)
        {
            body.gravityScale = fallGravityScale; 
        }
        else
        {
            body.gravityScale = gravityScale;
        }   
    }

    private void Jump()
    {  
        animator.SetBool("IsJumping", true);
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        airspeed = 1.2F;        
    }

    private void DoubleJump()
    {
        animator.SetBool("IsDoubleJumping", true);
        animator.SetBool("IsJumping", false);
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        airspeed = 0.8F;
        jumpCount = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
            jumpCount = 0;
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsDoubleJumping", false);
        }
    }


    private bool isGrounded() 
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
   
}
