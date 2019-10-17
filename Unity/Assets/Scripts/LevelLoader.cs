using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int curSceneIndex;
    private const int MAIN_MENU_SCENE_INDEX = 0;
    private const int GAME_COMPLETE_SCENE_INDEX = 4;
    private const int GAME_OVER_SCENE_INDEX = 5;

    private void Start()
    {
        curSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private IEnumerator ChangeScene(int sceneBuildIndex, float sceneLoadDelay)
    {
        yield return new WaitForSecondsRealtime(sceneLoadDelay);
        
        if (sceneBuildIndex == MAIN_MENU_SCENE_INDEX ||
            sceneBuildIndex == GAME_COMPLETE_SCENE_INDEX ||
            sceneBuildIndex == GAME_OVER_SCENE_INDEX)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }

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
        StartCoroutine(ChangeScene(GAME_OVER_SCENE_INDEX, sceneLoadDelay));
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
