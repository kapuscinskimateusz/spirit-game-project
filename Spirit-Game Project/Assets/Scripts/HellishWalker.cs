using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellishWalker : Enemy
{
    public float enemyTerritory = 3f;
    public float attackRange = 0.8f;

    public Transform attackPoint;
    public LayerMask playerLayer;

    private Rigidbody2D rb;
    private Animator animator;

    private enum State
    {
        Patrolling,
        ChaseTarget,
        Attacking
    }

    private State state;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        state = State.Patrolling;
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Patrolling:
                Patrol();
                break;
            case State.ChaseTarget:
                ChaseTarget();
                break;
            case State.Attacking:
                animator.SetTrigger("Attack");
                break;
        }
    }

    public override void Patrol()
    {
        base.Patrol();

        if (Vector2.Distance(player.position, rb.position) <= enemyTerritory)
        {
            state = State.ChaseTarget;
        }
    }

    private void ChaseTarget()
    {
        LookAtPlayer();

        if (Vector2.Distance(player.position, rb.position) >= enemyTerritory)
        {
            state = State.Patrolling;
        }

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == true)
        {
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            state = State.Attacking;
        }
    }

    public override void Attack()
    {
        animator.ResetTrigger("Attack");

        Collider2D hitInfo = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);
        if (hitInfo)
        {
            base.Attack();
        }

        state = State.ChaseTarget;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
