using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonController : MonoBehaviour
{
    private void Start()
    {
        BallsSpawnManager.Instance.SpawnBall(transform.position);
    }
}