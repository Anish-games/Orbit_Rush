using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpike : MonoBehaviour
{
    public float rotationAngle = 90f;
    public float patrolSpeed = 2f;
    public Vector3 pointA;
    public Vector3 pointB;
    private Vector3 targetPoint;

    
    private void Start() => SetPatrolPoints();
    private void Update()
    {
        RotateSpikeBall();
        PatrolPlatform();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            Transform PlayerPosition = collision.gameObject.transform;
            //transform.localScale = new Vector2(-Mathf.Sign(PlayerPosition.localScale.x), PlayerPosition.localScale.y);
            playerController.DamagePlayer();
        }
    }
    private void SetPatrolPoints()
    {
        transform.position = pointA;
        targetPoint = pointB;
    }
    private void RotateSpikeBall() => transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
    private void PatrolPlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, patrolSpeed * Time.deltaTime);
        if (transform.position == targetPoint)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
        }
    }
}