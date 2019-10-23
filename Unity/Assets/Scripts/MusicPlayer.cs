using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip mainMenuMusic;
    [SerializeField] AudioClip gameOverMenuMusic;
    [SerializeField] AudioClip level1Music;
    [SerializeField] AudioClip level2Music;
    [SerializeField] AudioClip level3Music;
    [SerializeField] AudioClip victoryClip;

    Scene startScene;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startScene = SceneManager.GetActiveScene();

        switch (startScene.buildIndex)
        {
            case SceneIndices.MAIN_MENU_INDEX:
                audioSource.clip = mainMenuMusic;
                break;
            case SceneIndices.GAME_OVER_MENU_INDEX:
                audioSource.clip = gameOverMenuMusic;
                break;
            case SceneIndices.LEVEL_1_INDEX:
                audioSource.clip = level1Music;
                break;
            case SceneIndices.LEVEL_2_INDEX:
                audioSource.clip = level2Music;
                break;
            case SceneIndices.LEVEL_3_INDEX:
                audioSource.clip = level3Music;
                break;
            case SceneIndices.CREDITS:
                audioSource.clip = gameOverMenuMusic;
                break;
            default:
                Debug.Log("No music clip available.");
                break;
        }

        if (startScene.buildIndex == SceneIndices.GAME_COMPLETE_MENU_INDEX)
        {
            audioSource.PlayOneShot(victoryClip);
        }
        else
        {
            audioSource.Play();
        }
    }
}
