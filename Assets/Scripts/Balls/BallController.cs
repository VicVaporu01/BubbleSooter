using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class BallController : Ball
{
    private Rigidbody2D ballRB;

    [SerializeField] private float ballDetectRadius = 1.0f;
    [SerializeField] private bool canDestroy = false;
    [SerializeField] private bool ballVisited = false;
    [SerializeField] private float velocity;

    private void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        velocity = ballRB.velocity.magnitude;

        DestroyBall();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        BallController otherBallController = other.gameObject.GetComponent<BallController>();
        BallColor colliderColor = otherBallController.ballColor;

        if (gameObject.CompareTag("StaticBall") && other.gameObject.CompareTag("PlayerBall"))
        {
            // First lets transform the player ball into a normal ball
            otherBallController.ballRB.velocity = Vector2.zero;
            otherBallController.ballRB.angularVelocity = 0.0f;
            otherBallController.gameObject.tag = "StaticBall";

            DestroyAdjacentSameColorBalls(colliderColor);
        }
    }

    private void DestroyAdjacentSameColorBalls(BallColor hitColor)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, ballDetectRadius);

        foreach (Collider2D ball in hits)
        {
            BallController adjacentBallController = ball.gameObject.GetComponent<BallController>();
            if (ballColor == hitColor && !adjacentBallController.ballVisited)
            {
                ballVisited = true;
                canDestroy = true;
                adjacentBallController.DestroyAdjacentSameColorBalls(hitColor);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ballDetectRadius);
    }

    public void DestroyBall()
    {
        if (canDestroy)
        {
            gameObject.SetActive(false);
            canDestroy = false;
            ballVisited = false;
        }
    }
}

// Enum for the ball colors
public enum BallColor
{
    Blue,
    Brown,
    Green,
    Red,
    White,
    Yellow
}