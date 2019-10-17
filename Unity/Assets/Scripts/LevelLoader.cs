using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;

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

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
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
