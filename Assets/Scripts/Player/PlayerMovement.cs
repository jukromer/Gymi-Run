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
    [SerializeField] Animator cameraAnimator;
    [SerializeField] float fallGravityScale = 5f;
    public float gravityScale = 3f;
    [SerializeField] private bool isGrounded;
    [SerializeField] GameObject playerObject;
    [SerializeField] float KillHeight;
    [SerializeField] PlayerHealth playerHealth;
    bool isStomping;
    private string currentState;
    [SerializeField] float StompSpeed;
    [SerializeField] Vector2 playerVelocity;
    [SerializeField] float TopSpeed;
    [SerializeField] float lowSpeed;
    
    [SerializeField] private AudioSource jumpSoundEffect;

    private void Awake()
    {
        speed = 0f;
        body = GetComponent<Rigidbody2D>();
        body.gravityScale = gravityScale;
        body.drag = 0;
        body.angularDrag = 0;
        boxCollider = GetComponent<BoxCollider2D>();
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        isStomping = false;
    }

    private void Update()
    {        
        SpeedDisplay();
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
            {   
                isGrounded = false;           
                jumpCount++;
                Jump();  
            }
            else if(!isGrounded && jumpCount == 0)
            {
                jumpCount = 2;
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
        fallGravityScale = 5f;
        jumpSoundEffect.Play();
        animator.SetBool("IsStomping", false);
        animator.SetBool("IsJumping", true);
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        airspeed = 1.2F;        
    }

    private void DoubleJump()
    {
        fallGravityScale = 5f;
        jumpSoundEffect.Play();
        animator.SetBool("IsStomping", false);
        animator.SetBool("IsDoubleJumping", true);
        animator.SetBool("IsJumping", false);
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        airspeed = 0.8F;
        jumpCount = 2;
    }

    private void Stomp()
    {
        fallGravityScale = 0f;
        isStomping = true;
        animator.SetBool("IsStomping", true);
        body.velocity = new Vector2(body.velocity.x, StompSpeed);
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsDoubleJumping", false);
    }
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        speed = 10f;
        fallGravityScale = 5f;
        isGrounded = true;
        jumpCount = 0;
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsDoubleJumping", false);
        animator.SetBool("IsStomping", false);
        if(isStomping)
        {
            ChangeAnimationState("CameraShake");
            isStomping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        isGrounded = false;
    }

    public void ChangeAnimationState(string newState)
    {
        // if(currentState == newState) return;
        cameraAnimator.Play(newState, -1, 0f);
        currentState = newState;
    }

    private void SpeedDisplay()
    {
        playerVelocity = new Vector2(body.velocity.x, body.velocity.y);
        if(body.velocity.y > TopSpeed)
        {
            TopSpeed = body.velocity.y;
        }
        if(body.velocity.y < lowSpeed)
        {
            lowSpeed = body.velocity.y;
        }
        if(PlayerManager.CharacterAnimator != null)
        {
            animator  = PlayerManager.CharacterAnimator;
        }
    }

    public void ResetPlayerVelocity()
    {
        body.velocity = new Vector2(0f, 0f);
    }

    public void ResetGravity()
    {
        gravityScale = 3f;
        fallGravityScale = 5f; 
    }

    public void toggleIsStomping(bool state)
    {
        isStomping = state;
    }

    public void ResetPlayerMovement()
    {
        ResetGravity();
        ResetPlayerVelocity();
        toggleIsStomping(false);
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    public int getJumpCount()
    {
        return jumpCount;
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
   
}
