using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;   // for TextMeshPro UI

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance; 
    public GameObject pauseMenu;
    public static bool isPaused = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                ShowPause();
            }
        }
    }

    public void ShowPause()
    {
        
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // pause game
        isPaused = true;

    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
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
