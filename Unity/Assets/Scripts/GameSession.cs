using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 5;
    [SerializeField] int score = 0;

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    private LevelLoader levelLoader;

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
        levelLoader = FindObjectOfType<LevelLoader>();
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            ReduceLivesAndUpdateUI();
            levelLoader.ReloadCurrentLevel();
        }
        else
        {
            levelLoader.LoadGameOverMenu();
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

    public void ResetSession()
    {
        Destroy(gameObject);
    }
}
