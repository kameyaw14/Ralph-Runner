

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI gameOverHighScoreText; // Reference to the High Score Text on Game Over screen
    [SerializeField] private ScoreManager scoreManager; // Reference to the ScoreManager

    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject pauseButton;


    private void Awake()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        gameOverHighScoreText.text = "High Score: " + scoreManager.GetHighScore();

        Time.timeScale = 0;

       
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

       if(gameOverUI.activeInHierarchy)
        {
            pauseButton.SetActive(false);
        }

       if(pauseScreen.activeInHierarchy)
        {
            pauseButton.SetActive(false);
        }

       if(Time.timeScale > 0)
        {
            pauseButton.SetActive(true);
        }
     
    }

    public void Pause()
    {
        if (pauseScreen.activeInHierarchy)
        {
            PauseGame(false);
        }
        else
        {
            PauseGame(true);
        }
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
      
    }

    public void PauseGame(bool pause)
    {
        pauseScreen.SetActive(pause);

        if(pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

}

