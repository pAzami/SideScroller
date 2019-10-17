using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int curSceneIndex;
    private const int GAME_OVER_SCENE_IDENTIFIER = 5;

    private void Start()
    {
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private IEnumerator ChangeScene(int sceneBuildIndex, float sceneLoadDelay)
    {
        yield return new WaitForSecondsRealtime(sceneLoadDelay);
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void LoadMainMenu(float sceneLoadDelay = 0)
    {
        StartCoroutine(ChangeScene(0, sceneLoadDelay));
    }

    public void StartFirstLevel(float sceneLoadDelay = 0)
    {
        StartCoroutine(ChangeScene(1, sceneLoadDelay));
    }

    public void LoadNextLevel(float sceneLoadDelay = 0)
    {
        StartCoroutine(ChangeScene(curSceneIndex + 1, sceneLoadDelay));
    }

    public void ReloadCurrentLevel(float sceneLoadDelay = 0)
    {
        StartCoroutine(ChangeScene(curSceneIndex, sceneLoadDelay));
    }

    public void LoadGameOverMenu(float sceneLoadDelay = 0)
    {
        StartCoroutine(ChangeScene(GAME_OVER_SCENE_IDENTIFIER, sceneLoadDelay));
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
