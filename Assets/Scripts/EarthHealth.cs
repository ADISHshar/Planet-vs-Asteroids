using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EarthHealth : MonoBehaviour
{
    public int lives = 10;
    public GameObject gameOverScreen;
    public TMPro.TextMeshProUGUI livesText;

    void Start()
    {
        UpdateLivesText(); // Initialize the lives display
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
            lives--;
            UpdateLivesText(); // Update the display

            if (lives <= 0)
            {
                gameOverScreen.SetActive(true);
                Time.timeScale = 0; // Pause the game
            }
        }
    }

    void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;
    }
}
