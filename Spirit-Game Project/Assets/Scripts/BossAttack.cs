using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float attackRange = 3f;

    public Transform attackPoint;
    public LayerMask playerLayer;

    public void Attack()
    {
        Collider2D hitInfo = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);
        if (hitInfo)
            HealthManager.instance.TakeDamage(1);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
