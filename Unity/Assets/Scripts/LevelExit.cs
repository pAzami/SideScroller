using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float exitDelay = 2f;
    [SerializeField] AudioClip exitSFX;

    private bool levelExitTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!levelExitTriggered)
        {
            StartCoroutine(PrepareLevelExit());
        }
    }

    private IEnumerator PrepareLevelExit()
    {
        levelExitTriggered = true;
        GetComponent<SpriteRenderer>().color = Color.green;
        AudioSource.PlayClipAtPoint(exitSFX, Camera.main.transform.position);

        yield return new WaitForSecondsRealtime(exitDelay);

        FindObjectOfType<ScenePersist>().destroyAllCollectibles();
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }

}
