using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    [Tooltip ("Game units per second")]
    [SerializeField] float rate = 0.4f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, rate * Time.deltaTime));
    }
}
