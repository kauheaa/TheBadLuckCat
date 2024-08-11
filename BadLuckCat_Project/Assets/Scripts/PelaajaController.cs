using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PelaajaController : MonoBehaviour
{

    public float fallMultiplier = 2.5f;
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal"); 
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);  // Pelaajan liikuttaminen -1 & 1 suuntaan.
    }

    void Update()
    {
        


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneSwitcher.instance.OnPause();
        }
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(moveInput > 0){
            transform.eulerAngles = new Vector3(0, 0, 0);
            animator.SetBool("isWalking", true);
        } else if (moveInput < 0){
            transform.eulerAngles = new Vector3(0, 180, 0);
            animator.SetBool("isWalking", true);
        } else
        {
            animator.SetBool("isWalking", false);
        }

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)){
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", true);
            animator.SetTrigger("Jump");
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true){

            if (jumpTimeCounter > 0)
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;
        } else{
            isJumping = false;
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            isJumping = false;
            animator.SetBool("isJumping", false);
        }

        if (rb.velocity.y < 0)      //Nopeampi putoaminen
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneSwitcher.instance.OnDeath();
        }
    }
}
