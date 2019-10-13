using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    Player player;

    private float smoothTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetCamPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetCamPos, smoothTime * Time.deltaTime);
        transform.position = smoothPos;
    }
}
