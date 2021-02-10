using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collInfo)
    {
        if (collInfo.gameObject.CompareTag("Player"))
        {
            GameManager.instance.lastCheckPointPos = transform.position;
        }
    }
}
