using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    private const String GAME_OVER_SCENE_IDENTIFIER = "Game Over";

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            ReduceLivesAndUpdateUI();
            ReloadCurrentLevel();
        }
        else
        {
            LoadGameOverScene();
        }
    }

    public void IncreaseScoreAndUpdateUI(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    private void ReduceLivesAndUpdateUI()
    {
        playerLives--;
        livesText.text = playerLives.ToString();
    }

    private void ReloadCurrentLevel()
    {
        var curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curSceneIndex);
    }

    public void ResetSession()
    {
        Destroy(gameObject);
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene(GAME_OVER_SCENE_IDENTIFIER);
    }
}
