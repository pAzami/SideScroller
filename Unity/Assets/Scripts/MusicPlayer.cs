using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip MainMenuMusic;
    [SerializeField] AudioClip GameOverMenuMusic;
    [SerializeField] AudioClip GameCompleteMenuMusic;
    [SerializeField] AudioClip level1Music;
    [SerializeField] AudioClip level2Music;
    [SerializeField] AudioClip level3Music;

    Scene startScene;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startScene = SceneManager.GetActiveScene();

        switch (startScene.buildIndex)
        {
            case SceneIndices.MAIN_MENU_INDEX:
                audioSource.clip = MainMenuMusic;
                break;
            case SceneIndices.GAME_OVER_MENU_INDEX:
                audioSource.clip = GameOverMenuMusic;
                break;
            case SceneIndices.GAME_COMPLETE_MENU_INDEX:
                audioSource.clip = GameCompleteMenuMusic;
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
            default:
                Debug.Log("No music clip available.");
                break;
        }

        audioSource.Play();
    }
}
