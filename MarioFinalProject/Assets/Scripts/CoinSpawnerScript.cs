using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;  // Prefab for the coin
    public float spawnRangeX = 10f;  // Horizontal range for spawning coins
    public float spawnRangeY = 5f;   // Vertical range for spawning coins

    void Start()
    {
        // Start spawning coins repeatedly with an initial delay of 2 seconds, and then every 2 seconds
        InvokeRepeating("SpawnCoin", 2f, 2f);
    }

    void SpawnCoin()
    {
        // Generate random positions within the specified range
        float randomX = transform.position.x + Random.Range(-spawnRangeX, spawnRangeX);
        float randomY = transform.position.y + Random.Range(-spawnRangeY, spawnRangeY);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        // Instantiate the coin prefab at the random position
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}