using UnityEngine;
using UnityEngine.SceneManagement; // Import this namespace for scene management
using UnityEngine.UI; // Import this namespace for UI components

public class PlayButtonScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}