using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolPlayerBalls : MonoBehaviour
{
    [SerializeField] private GameObject[] ballsPrefabs;
    [SerializeField] private List<GameObject> playerBalls;

    private int playerBallsColors = 6;

    private void Start()
    {
        int ballSameColor = 0;
        for (int i = 0; i < playerBallsColors; i++)
        {
            while (ballSameColor < 10)
            {
                GameObject ball = GenerateBalls(i);
                playerBalls.Add(ball);

                ballSameColor += 1;
            }

            ballSameColor = 0;
        }
    }

    private GameObject GenerateBalls(int ballPosition)
    {
        GameObject ball = Instantiate(ballsPrefabs[ballPosition], transform);
        ball.SetActive(false);

        return ball;
    }

    public GameObject RequestBall(BallColor ballColor)
    {
        foreach (GameObject ball in playerBalls)
        {
            if (ball.GetComponent<BallController>().ballColor == ballColor && !ball.activeSelf)
            {
                ball.gameObject.tag = "PlayerBall";
                ball.transform.position = transform.position;

                // Lets reset the ball velocity and angular velocity
                Rigidbody2D ballRB = ball.GetComponent<Rigidbody2D>();
                ballRB.velocity = Vector2.zero;
                ballRB.angularVelocity = 0.0f;

                ball.SetActive(true);

                return ball;
            }
        }

        return null;
    }
}