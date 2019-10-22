using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float exitDelay = 2f;
    [SerializeField] AudioClip exitSFX;

    [Range(0f, 1f)]
    [SerializeField] float sfxVolume = 1f;

    private bool levelExitTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!levelExitTriggered)
        {
            Exit();
        }
    }

    private void Exit()
    {
        levelExitTriggered = true;
        GetComponent<SpriteRenderer>().color = Color.green;
        AudioSource.PlayClipAtPoint(exitSFX, Camera.main.transform.position, sfxVolume);

        FindObjectOfType<ScenePersist>().destroyPersistantItems();
        FindObjectOfType<LevelLoader>().LoadNextLevel(exitDelay);
    }

}
