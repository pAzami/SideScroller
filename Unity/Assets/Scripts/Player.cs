using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Rigidbody2D playerRigidBody;
    Animator playerAnimator;

    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        run();
        FlipSprite();
    }

    private void run()
    {
        float inputAxis = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(inputAxis * moveSpeed, playerRigidBody.velocity.y);
        playerRigidBody.velocity = velocity;

        bool hasHorizontalMovement = Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("Running", hasHorizontalMovement);
    }

    private void FlipSprite()
    {
        bool hasHorizontalMovement = Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon;
        if (hasHorizontalMovement)
        {
            transform.localScale =  new Vector2 (Mathf.Sign(playerRigidBody.velocity.x), 1f);
        }
    }
}
