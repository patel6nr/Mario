using UnityEngine;
using _app.Scripts.Managers;

public class MarioScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpStrength;
    public LogicScript logic;
    public bool marioIsAlive = true;
    public AudioClip deathSound; // Add this field for the death sound

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic")?.GetComponent<LogicScript>();
        if (logic == null)
        {
            Debug.LogError("LogicScript component not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && marioIsAlive)
        {
            myRigidbody.velocity = Vector2.up * jumpStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    private void OnBecameInvisible()
    {
        GameOver();
        marioIsAlive = false;
    }

    private void GameOver()
    {
        if (marioIsAlive)
        {
            logic?.gameOver();
            marioIsAlive = false;

            // Play death sound
            if (deathSound != null)
            {
                if (AudioManager.Instance != null)
                {
                    AudioManager.Instance.audioSource.clip = deathSound;
                    AudioManager.Instance.audioSource.Play();
                    Debug.Log("Death sound played.");
                }
                else
                {
                    Debug.LogWarning("AudioManager instance is not available.");
                }
            }
            else
            {
                Debug.LogWarning("Death sound is not assigned.");
            }

            // Optionally: Additional game over logic (e.g., stop player movement, show game over screen)
        }
    }
}