using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public GameObject startPanel; // Assign in inspector

    void Start()
    {
        Time.timeScale = 0f; // Pause game until start
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f; // Resume game
    }
}
