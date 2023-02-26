using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim; //not animation
    private float  dirX= 0f;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 16f;
    private bool doubleJump;

    private enum MovementState {idle,running,jumping,falling }

    [SerializeField] private AudioSource jumpSoundEffect;
    
   // int wholeNumber = 16;
   //float decimalNumber = 4.54f;
   //string text = "Hi Sinem";
   //bool boolean = false;

    // Start is called before the first frame update
    private void Start()
    {
        //command line
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim =GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*moveSpeed, rb.velocity.y);

        if(IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        //it works if isGrounded is true or doubleJump is active
        if (Input.GetButtonDown("Jump"))
        {   
            if(IsGrounded() || doubleJump)
        
            {
                jumpSoundEffect.Play();
                //Debug.Log("Jumping");
                //Get key down , sürekli space engeller onun yerine GetKey
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = !doubleJump;
            }
        }

        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {   
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX <0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        //jumping has higher importance
        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private  bool IsGrounded() //preventing jumping high points
    //if we are touching the ground or not
    //bir box oluşuturup bu box groundu overlap ediyor mu kontrol ettik(geçiyor mu)
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround );

    }
}
