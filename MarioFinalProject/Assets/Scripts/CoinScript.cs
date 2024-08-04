using UnityEngine;
using _app.Scripts.Managers;

public class CoinScript : MonoBehaviour
{
    public float moveSpeed = -5f;  // Speed at which the coin moves
    public int scoreValue = 1;     // Points awarded for collecting the coin
    public AudioClip coinCollectSound;  // Sound to play when the coin is collected
    private LogicScript logic;
    private bool hasBeenCollected = false; // Flag to track if the coin has been collected

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic")?.GetComponent<LogicScript>();
        if (logic == null)
        {
            Debug.LogError("LogicScript component not found!");
        }

        if (coinCollectSound == null)
        {
            Debug.LogWarning("Coin collect sound is not assigned in the Inspector.");
        }
        else
        {
            Debug.Log("Coin collect sound assigned correctly.");
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
        Debug.Log($"OnTriggerEnter2D called with {col.name}");
        if (col.CompareTag("Player") && !hasBeenCollected)
        {
            hasBeenCollected = true; // Set the flag to true to prevent further triggers

            // Add score when the coin is collected
            logic?.addScore(scoreValue);

            // Play the coin collection sound
            if (coinCollectSound != null)
            {
                if (AudioManager.Instance != null)
                {
                    AudioManager.Instance.audioSource.clip = coinCollectSound;
                    AudioManager.Instance.audioSource.Play();
                    Debug.Log("Coin collected sound played.");
                }
                else
                {
                    Debug.LogWarning("AudioManager instance is not available.");
                }
            }
            else
            {
                Debug.LogWarning("Coin collect sound is not assigned.");
            }

            // Destroy the coin
            Destroy(gameObject);
        }
    }

    }

