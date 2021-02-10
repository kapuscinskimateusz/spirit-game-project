using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDemon : Enemy
{
    private void Update()
    {
        Patrol();
    }

    public override void Attack()
    {
        base.Attack();

        HealthSystem.instance.TakeDamage(1);
    }

    private void OnCollisionEnter2D(Collision2D collInfo)
    {
        Attack();
    }
}
