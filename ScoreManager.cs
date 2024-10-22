


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private TextMeshProUGUI highScoreDisplay;

    private int highScore;

    private void Start()
    {
        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreDisplay();
    }

    private void Update()
    {
        scoreDisplay.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            score++;
            Debug.Log(score);

            // Update high score if necessary
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HighScore", highScore);
                PlayerPrefs.Save();
            }

            UpdateScoreDisplay();
        }
    }

    private void UpdateScoreDisplay()
    {
        scoreDisplay.text = "Score: " + score;
        highScoreDisplay.text = "High Score: " + highScore;
    }

    public int GetHighScore()
    {
        return highScore;
    }
}

