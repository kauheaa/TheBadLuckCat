using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float jumpForce = 10f, fallMultiplier = 2.5f;
    private float xScale;

    private Rigidbody2D rb;
    private Animator animator;

    //Pidemmälle hypylle --- EI TOIMINUT
    //private bool isGrounded;
    //public Transform pawPosition;
    //public float checkRadius;
    //public LayerMask whatIsGround;
    //private float jumpTimer;
    //public float jumpTime;
    //private bool isJumping;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        xScale = transform.localScale.x;
    }

    private void FixedUpdate()
    {

    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)       //&& jälkeinen estää loputtoman hyppäämisen
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
            animator.SetTrigger("Jump");
        }
        if (rb.velocity.y < 0)      //Nopeampi putoaminen
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        //EI TOIMINUT KORKEAKSI HYPYKSI
    //    isGrounded = Physics2D.OverlapCircle(pawPosition.position, checkRadius, whatIsGround);
        
    //    if (isGrounded == true && Input.GetButtonDown("Jump"))
    //    {
    //        isJumping = true;
    //        jumpTimer = jumpTime;
    //        rb.velocity = Vector2.up * jumpForce;
    //    }

    //    if (Input.GetButton("Jump") && isJumping == true)
    //    {
    //        if(jumpTimer > 0)
    //        {
    //            rb.velocity = Vector2.up * jumpForce;
    //            jumpTimer -= Time.deltaTime;
    //        } 
    //        else
    //        {
    //            isJumping = false;
    //        }
    //    }

    //    if (Input.GetButtonUp("Jump"))
    //    {
    //        isJumping = false;
    //    }
    }
    

    private void HandleMovement()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
        if (movement != 0f)
        {
            transform.localScale = new Vector3(xScale * movement, transform.localScale.y, transform.localScale.z);
        }

        animator.SetBool("Walking", movement != 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            animator.SetBool("Jumping", false);
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            animator.SetBool("Walking", true);
        }
    }


}
