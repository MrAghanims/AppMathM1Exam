using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;   // for TextMeshPro UI

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance; // singleton for easy access
    public GameObject gameOverMenu;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ShowGameOver()
    {
        gameOverMenu.SetActive(true);

        int finalScore = ScoreManager.Instance.GetScore();
        scoreText.text = "Score: " + finalScore;

        Time.timeScale = 0f; // pause game
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; // resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    { 
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game quit!");
    }
}
