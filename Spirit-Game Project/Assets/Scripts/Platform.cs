using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 5f;

    public Transform targetPoint;
    private Vector2 startPosition, targetPosition;

    private bool isMoving = false;
    private bool isMovingToTargetPoint;

    public enum Type
    {
        LeftRight,
        UpDown
    }

    public Type type;

    private void Start()
    {
        startPosition = transform.position;
        targetPosition = targetPoint.position;
    }

    private void Update()
    {
        if (isMoving)
        {
            if (isMovingToTargetPoint)
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            else
                transform.position = Vector2.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);

            switch (type)
            {
                case Type.LeftRight:
                    if (transform.position.x >= targetPosition.x)
                        isMovingToTargetPoint = false;
                    if (transform.position.x <= startPosition.x)
                        isMovingToTargetPoint = true;
                    break;
                case Type.UpDown:
                    if (transform.position.y >= targetPosition.y)
                        isMovingToTargetPoint = false;
                    if (transform.position.y <= startPosition.y)
                        isMovingToTargetPoint = true;
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collInfo)
    {
        collInfo.collider.transform.SetParent(transform);
        isMoving = true;
    }

    private void OnCollisionExit2D(Collision2D collInfo)
    {
        collInfo.collider.transform.SetParent(null);
    }
}
