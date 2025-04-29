using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentWins = 0;
    public Text winText;
    public GameObject resultPanel;
    public Text resultText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateWinText();
    }

    public void HandleResult(bool isWin)
    {
        if (isWin)
        {
            currentWins++;
            UpdateWinText();

            if (currentWins >= 5)
                ShowResult("You Won!");
        }
        else
        {
            ShowResult("You Lost!");
        }
    }

    void UpdateWinText()
    {
        winText.text = "Wins: " + currentWins + " / 5";
    }

    void ShowResult(string msg)
    {
        resultPanel.SetActive(true);
        resultText.text = msg;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
