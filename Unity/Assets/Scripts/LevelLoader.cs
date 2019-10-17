using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;

    private int curSceneIndex;
    private const string GAME_OVER_SCENE_IDENTIFIER = "Game Over";

    private void Start()
    {
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    public IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);

        SceneManager.LoadScene(curSceneIndex + 1);
    }

    public void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(curSceneIndex);
    }

    public void LoadGameOverMenu()
    {
        SceneManager.LoadScene(GAME_OVER_SCENE_IDENTIFIER);
    }

    public void QuitToMainMenu()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {
            FindObjectOfType<GameSession>().ResetSession();
        }

        LoadMainMenu();

    }

    public void Quit()
    {
        Application.Quit();
    }
}
