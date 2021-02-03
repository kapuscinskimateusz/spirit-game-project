using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveInput = 0f;
    public float moveSpeed;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundMask;
    public float jumpForce;

    private Rigidbody2D rb;
    private Animator animator;

    private bool isFacingRight = true;
    private bool isGrounded = false;

    private bool isJumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
        moveInput = Input.GetAxis("Horizontal");

        if (isGrounded)
        {
            animator.SetFloat("Velocity", Mathf.Abs(moveInput));
        }

        if (rb.velocity.y < 0 && !isGrounded)
        {
            animator.SetBool("IsFalling", true);
            animator.Play("Player_Falling");
        }

        if (animator.GetBool("IsFalling") && isGrounded)
        {
            animator.SetBool("IsFalling", false);
            animator.Play("Player_Landing");
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetBool("IsPrejump", true);
            animator.Play("Player_Prejump");
        }

        if (Input.GetButtonUp("Jump") && isGrounded && animator.GetBool("IsPrejump"))
        {
            animator.SetBool("IsPrejump", false);
            isJumping = true;
            animator.Play("Player_Jump");
        }
    }

    private void FixedUpdate()
    {
        if (!animator.GetBool("IsPrejump"))
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
