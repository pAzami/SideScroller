using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    private bool levelExitTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!levelExitTriggered)
        {
            levelExitTriggered = true;
            GetComponent<SpriteRenderer>().color = Color.green;
            FindObjectOfType<ScenePersist>().destroyAllCollectibles();
            StartCoroutine(FindObjectOfType<LevelLoader>().LoadNextLevel());
        }
    }

}
