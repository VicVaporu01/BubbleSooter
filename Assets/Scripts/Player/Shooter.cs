using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [SerializeField] private PoolPlayerIndicators poolPlayerIndicators;
    [SerializeField] private PoolPlayerBalls poolPlayerBalls;
    [SerializeField] private Transform ballColorIndicator;

    private GameObject indicator;
    [SerializeField] private BallColor currentIndicatorColor;
    private int colorsAmount = 6;

    private void Start()
    {
        GenerateIndicator();
    }

    private void GenerateIndicator()
    {
        int randomIndicator = Random.Range(0, colorsAmount);

        indicator = poolPlayerIndicators.RequestIndicator(randomIndicator);
        indicator.GetComponent<IndicatorController>().indicatorPosition = ballColorIndicator;

        indicator.transform.position = ballColorIndicator.position;
        currentIndicatorColor = indicator.GetComponent<IndicatorController>().ballColor;
    }

    public void ShootBall(InputAction.CallbackContext callbackContext)
    {
        // This condition is to shoot only 1 time per click
        if (callbackContext.started)
        {
            indicator.SetActive(false);

            GameObject ball = poolPlayerBalls.RequestBall(currentIndicatorColor);
            if (ball != null)
            {
                Rigidbody2D ballRB = ball.GetComponent<Rigidbody2D>();

                ball.transform.position = transform.position;
                ballRB.velocity = transform.up * 5.0f;
                GenerateIndicator();
            }
            else
            {
                Debug.Log("Ball is null");
            }
        }
    }

    public void ChangeBallToShoot(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
        {
            indicator.SetActive(false);

            GenerateIndicator();
        }
    }
}