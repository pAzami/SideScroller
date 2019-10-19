using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Tooltip("Movement duration in each direction")]
    [SerializeField] float movementInSecs = 3f;

    [Tooltip("Initial movement direction")]
    [SerializeField] bool movingDown = true;

    [SerializeField] float moveSpeed = 2f;

    Rigidbody2D rigidBody;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        timer = movementInSecs;
    }


    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        ChangeDirectionAndResetTimer();
        Move();
    }

    private void Move()
    {
        if (movingDown)
        {
            rigidBody.velocity = new Vector2(0f, -moveSpeed);
        }
        else
        {
            rigidBody.velocity = new Vector2(0f, moveSpeed);
        }
    }

    private void ChangeDirectionAndResetTimer()
    {
        if (timer <= 0)
        {
            movingDown = !movingDown;
            timer = movementInSecs;
        }
    }

    private void UpdateTimer()
    {
        timer -= Time.deltaTime;
    }
}
