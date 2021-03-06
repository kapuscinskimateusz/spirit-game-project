using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float distance = 1f;
    public int attackDamage = 1;

    public Transform groundDetection;
    public Transform player;

    private bool movingRight = true;

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
        HealthManager.instance.TakeDamage(attackDamage);
    }

    protected void LookAtPlayer()
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
