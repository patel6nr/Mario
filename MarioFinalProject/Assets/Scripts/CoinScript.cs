using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float moveSpeed = -5f;  // Speed at which the coin moves
    public int scoreValue = 1;     // Points awarded for collecting the coin
    private LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic")?.GetComponent<LogicScript>();
        if (logic == null)
        {
            Debug.LogError("LogicScript component not found!");
        }
        Destroy(gameObject, 9f); // Destroy the coin after 9 seconds if not collected
    }

    void Update()
    {
        // Move the coin horizontally
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // Add score when the coin is collected
            logic?.addScore(scoreValue);
            
            // Destroy the coin
            Destroy(gameObject);
        }
    }
}