using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingLeft())
        {
            rigidBody.velocity = new Vector2(-moveSpeed, 0f);  // move left
        }
        else
        {
            rigidBody.velocity = new Vector2(moveSpeed, 0f);  // move right
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(+(Mathf.Sign(rigidBody.velocity.x)), 1f);
    }

    private bool IsFacingLeft()
    {
        return transform.localScale.x > 0;
    }
}
