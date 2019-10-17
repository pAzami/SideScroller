using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float exitDelay = 2f;

    private bool levelExitTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!levelExitTriggered)
        {
            levelExitTriggered = true;
            GetComponent<SpriteRenderer>().color = Color.green;
            FindObjectOfType<ScenePersist>().destroyAllCollectibles();
            FindObjectOfType<LevelLoader>().LoadNextLevel(exitDelay);
        }
    }

}
