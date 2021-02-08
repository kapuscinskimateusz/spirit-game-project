using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundMask;
    public float moveSpeed = 10f;
    public float jumpForce = 400f;
    private float moveInput = 0f;

    private Rigidbody2D rb;
    private Animator animator;
    private PlayerAttack playerAttack;

    private bool isFacingRight = true;

    private bool isGrounded = false;
    public bool isPrejumping = false;
    private bool isJumping = false;
    private bool isFalling = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
        moveInput = Input.GetAxis("Horizontal");

        if (isGrounded)
        {
            animator.SetFloat("xVelocity", Mathf.Abs(moveInput));
        }
        else
        {
            isPrejumping = false;
        }

        if (!GameManager.instance.gameIsFrozen)
        {
            if (isGrounded && Input.GetButtonDown("Jump")) // PREJUMP ANIMATION
            {
                isPrejumping = true;
                animator.Play("Player_Prejump");
            }

            if (isGrounded && Input.GetButtonUp("Jump")) // JUMP
            {
                isJumping = true;
            }
        }

        if (!isGrounded && rb.velocity.y > 0 && !playerAttack.isAttacking) // JUMP ANIMATION
        {
            animator.Play("Player_Jump");
        }

        if (!isGrounded && rb.velocity.y < 0 && !playerAttack.isAttacking) // FALLING ANIMATION
        {
            isFalling = true;
            animator.Play("Player_Falling");
        }

        if (isFalling && isGrounded) // LANDING ANIMATION
        {
            isFalling = false;
            animator.Play("Player_Landing");
        }
    }

    private void FixedUpdate()
    {
        if (!isPrejumping)
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        else
            rb.velocity = Vector2.zero;

        if (isFacingRight == false && moveInput > 0)
        {
            FlipPlayer();
        }
        else if (isFacingRight == true && moveInput < 0)
        {
            FlipPlayer();
        }

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    private void FlipPlayer()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
