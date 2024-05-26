using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallsSpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> ballPrefabs;

    private static BallsSpawnManager instance;

    public static BallsSpawnManager Instance
    {
        get => instance;
        private set => instance = value;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void SpawnBall(Vector2 spawnPosition)
    {
        int randomBall = Random.Range(0, ballPrefabs.Count);
        GameObject ball = Instantiate(ballPrefabs[randomBall], transform);

        ball.transform.position = spawnPosition;
    }
}