using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 2.5f;

    public Transform target;
    private Vector2 pos1, pos2;

    private bool moveRight;

    private void Start()
    {
        pos1 = transform.position;
        pos2 = target.position;
    }

    private void Update()
    {
        if (moveRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= pos2.x)
            moveRight = false;
        if (transform.position.x <= pos1.x)
            moveRight = true;
    }

    private void OnCollisionEnter2D(Collision2D collInfo)
    {
        collInfo.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collInfo)
    {
        collInfo.collider.transform.SetParent(null);
    }
}
