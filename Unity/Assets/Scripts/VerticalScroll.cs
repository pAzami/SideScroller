using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    [Tooltip ("Game units per second")]
    [SerializeField] float rate = 0.4f;

    [Tooltip("Direction of verticle movement (up or down)")]
    [SerializeField] bool movingUp = true;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (movingUp)
        {
            transform.Translate(new Vector2(0f, rate * Time.deltaTime));
        }
        else
        {
            transform.Translate(new Vector2(0f, -rate * Time.deltaTime));
        }
    }
}
