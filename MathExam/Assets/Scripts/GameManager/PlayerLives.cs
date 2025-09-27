using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public int score = 0;
    public TextMeshProUGUI livesText;

    void Start()
    {
        UpdateLivesUI();
    }

    public void TakeHit()
    {
        lives--;

        UpdateLivesUI();

        if (lives <= 0)
        {
            GameOverManager.Instance.ShowGameOver();
        }
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }
}