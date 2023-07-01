using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private Transform player;
    [SerializeField] private float speed; //7 war gut
    [SerializeField] private float jumpHeight; //15 war gut
    [SerializeField] private LayerMask groundLayer;
    public float airspeed = 1.0F; //0.5
    public int jumpCount = 0;
    private BoxCollider2D boxCollider;
    public Animator animator;
    [SerializeField] float fallGravityScale = 5f;
    public float gravityScale = 3f;
    [SerializeField] private bool isGrounded;
    [SerializeField] GameObject playerObject;
    [SerializeField] float KillHeight;
    [SerializeField] PlayerHealth playerHealth;
    bool isStomping;
    //[SerializeField] Screenshake screenshake;
    
    

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = gravityScale;
        body.drag = 1;
        body.angularDrag = 0;
        boxCollider = GetComponent<BoxCollider2D>();
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        isStomping = false;
    }

    private void Update()
    {


        if(PlayerManager.CharacterAnimator != null)
        {
            animator  = PlayerManager.CharacterAnimator;
        }
        
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
            if(isGrounded && jumpCount == 0)
            {   isGrounded = false;           
                jumpCount++;
                Jump();  
            }
            else if(jumpCount == 1)
            {   
                DoubleJump();
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(isGrounded == false)
            {
                Stomp();
            }
        } 

        if(player.position.y < KillHeight)
        {
            playerHealth.Damage(100);
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

    private void Stomp()
    {
        isStomping = true;
        animator.SetBool("IsStomping", true);
        fallGravityScale = 40f;
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsDoubleJumping", false);
        if(body.velocity.y > 0)
        {
            body.velocity = new Vector2(body.velocity.x , body.velocity.y * -1f);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        fallGravityScale = 5f;
        isGrounded = true;
        jumpCount = 0;
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsDoubleJumping", false);
        animator.SetBool("IsStomping", false);
        if(isStomping)
        {
            //screenshake.Shake();
            isStomping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        isGrounded = false;
    }
   
}
