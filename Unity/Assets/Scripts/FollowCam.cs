using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothTime = 1f;

    [Header("Camera Boundaries"), Tooltip("These values will need changing when level boundary or camera size changes")]
    [SerializeField] float maxX = 6.6f;
    [SerializeField] float minX = -46.53f;
    [SerializeField] float maxY = 29.83f;
    [SerializeField] float minY = -42.82f;

    Vector3 velocity = Vector3.zero;

    private void Update()
    {
        Vector3 targetPosition = target.position;

        targetPosition.x = Mathf.Clamp(target.position.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(target.position.y, minY, maxY);
        targetPosition.z = transform.position.z;

        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPosition, smoothTime * Time.deltaTime);
        transform.position = smoothPos;
    }
}
