using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For scene management (if you want to reload the scene later)

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    public int keyCount = 0; // Number of keys the player has collected
    public int totalKeys = 3; // Total number of keys in the game (3 keys)

    [Header("Key UI")]
    public Image[] keyImages; // UI images for keys
    public Sprite goldKeySprite; // Gold key sprite to show when collected

    [Header("Game Over UI")]
    public GameObject gameCompleteUI; // Reference to the Game Completed UI panel
    public Text gameCompleteText; // Text for displaying the "Game Completed" message

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddKey()
    {
        if (keyCount < keyImages.Length)
        {
            keyImages[keyCount].sprite = goldKeySprite;
            keyCount++;
        }

        // Check if all keys have been collected
        if (keyCount >= totalKeys)
        {
            ShowGameComplete(); // Show the Game Completed message when all keys are collected
        }
    }

    // Show the Game Completed UI and freeze the game
    void ShowGameComplete()
    {
        if (gameCompleteUI != null)
        {
            gameCompleteUI.SetActive(true); // Activate the "Game Completed" UI
        }

        // Freeze the game by setting the time scale to 0
        Time.timeScale = 0f; // This stops all gameplay actions

        // Optional: Change the text on the Game Completed UI (e.g., for a custom message)
        if (gameCompleteText != null)
        {
            gameCompleteText.text = "Game Completed!";
        }
    }

    // Optional: Add functionality to restart the game
    public void RestartGame()
    {
        Time.timeScale = 1f; // Unfreeze the game by setting time scale back to 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene to restart
    }

    // Optional: Add functionality to quit the game
    public void QuitGame()
    {
        // You can quit the game here if you're building a standalone version
        Application.Quit();
    }
}
