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

    private const int MAIN_MENU = 0;
    private const int LEVEL_1 = 1;
    private const int LEVEL_2 = 2;
    private const int LEVEL_3 = 3;
    private const int GAME_COMPLETE_MENU = 4;
    private const int GAME_OVER_MENU = 5;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startScene = SceneManager.GetActiveScene();

        switch (startScene.buildIndex)
        {
            case MAIN_MENU:
                audioSource.clip = MainMenuMusic;
                break;
            case GAME_OVER_MENU:
                audioSource.clip = GameOverMenuMusic;
                break;
            case GAME_COMPLETE_MENU:
                audioSource.clip = GameCompleteMenuMusic;
                break;
            case LEVEL_1:
                audioSource.clip = level1Music;
                break;
            case LEVEL_2:
                audioSource.clip = level2Music;
                break;
            case LEVEL_3:
                audioSource.clip = level3Music;
                break;
            default:
                Debug.Log("No music clip available.");
                break;
        }

        audioSource.Play();
    }
}
