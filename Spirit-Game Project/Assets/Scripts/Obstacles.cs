using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collInfo)
    {
        if (collInfo.gameObject.CompareTag("Player"))
            HealthManager.instance.Die();
    }
}
