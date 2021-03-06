using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellishInsect : Enemy
{
    private void Update()
    {
        Patrol();
    }

    public override void Attack()
    {
        base.Attack();
        Knockback();
    }

    private void Knockback()
    {
        Vector2 impulse = new Vector2(player.transform.position.x - transform.position.x, 0f);
        player.gameObject.GetComponent<Rigidbody2D>().AddForce(impulse.normalized * 8000f);
    }

    private void OnCollisionEnter2D(Collision2D collInfo)
    {
        if (collInfo.gameObject.CompareTag("Player"))
        {
            Attack();
        }
    }
}
