using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

    public float moveSpeed = 2.5f;
    public float distance = 1f;

    private bool movingRight = true;

    public Transform groundDetection;

    public virtual void Patrol()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if (movingRight)
            {
                transform.Rotate(0, 180, 0);
                movingRight = false;
            }
            else
            {
                transform.Rotate(0, 180, 0);
                movingRight = true;
            }
        }
    }

    public virtual void Attack()
    {
        Debug.Log("Attack");
    }

    public void LookAtPlayer()
    {
        if (transform.position.x > player.position.x && movingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            movingRight = false;
        }
        else if (transform.position.x < player.position.x && !movingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            movingRight = true;
        }
    }
}
