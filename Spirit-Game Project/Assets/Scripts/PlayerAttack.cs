using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public LayerMask damageableLayers;

    public Transform attackPoint;

    private Animator animator;
    private PlayerMovement playerMovement;

    public bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !playerMovement.isPrejumping)
        {
            isAttacking = true;
            animator.Play("Player_Attack");
        }
    }

    private void Attack()
    {
        isAttacking = false;

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, damageableLayers);

        foreach (Collider2D hitObject in hitObjects)
        {
            hitObject.GetComponent<Damageable>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
