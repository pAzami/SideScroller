using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 14f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip jumpSFX;

    [Range(0f, 1f)]
    [SerializeField] float sfxVolume = 1f;

    Rigidbody2D playerRigidBody;
    Animator playerAnimator;
    CapsuleCollider2D bodyCollider;
    BoxCollider2D feetCollider;

    // Layers
    private const string GROUND_LAYER = "Ground";
    private const string MOVING_PLATFORM_LAYER = "MovingPlatform";
    private const string LADDER_LAYER = "Ladder";
    private const string PLAYER_LAYER = "Player";
    private const string ENEMY_LAYER = "Enemy";
    private const string TRAPS_LAYER = "Traps";

    // Animations
    private const string RUNNING_ANIM = "Running";
    private const string CLIMBING_ANIM = "Climbing";
    private const string DYING_ANIM = "Dying";
    private const string JUMP_ANIM = "Jump";

    // Player Input
    private const string VERTICAL_INPUT = "Vertical";
    private const string HORIZONTAL_INPUT = "Horizontal";
    private const string JUMP_INPUT = "Jump";

    private bool isAlive = true;
    private Vector3 mainCameraPos;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(PLAYER_LAYER), LayerMask.NameToLayer(ENEMY_LAYER), false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }

        mainCameraPos = Camera.main.transform.position;

        Run();
        FlipSprite();
        ClimbLadder();
        Jump();
        Die();
    }

    private void Die()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask(ENEMY_LAYER, TRAPS_LAYER)))
        {
            isAlive = false;
            playerAnimator.SetTrigger(DYING_ANIM);
            AudioSource.PlayClipAtPoint(deathSFX, mainCameraPos, sfxVolume);
            playerRigidBody.velocity = Vector2.zero;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(PLAYER_LAYER), LayerMask.NameToLayer(ENEMY_LAYER), true);
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }

    private void ClimbLadder()
    {
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask(LADDER_LAYER)))
        {
            playerAnimator.SetBool(CLIMBING_ANIM, false);
            return;
        }

        float inputAxis = Input.GetAxis(VERTICAL_INPUT);
        Vector2 ladderVelocity = new Vector2(playerRigidBody.velocity.x, inputAxis * climbSpeed);
        playerRigidBody.velocity = ladderVelocity;

        bool hasVerticalSpeed = Mathf.Abs(playerRigidBody.velocity.y) > Mathf.Epsilon;
        playerAnimator.SetBool(CLIMBING_ANIM, hasVerticalSpeed);
    }

    private void Jump()
    {
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask(GROUND_LAYER, MOVING_PLATFORM_LAYER))) { return; }

        if (Input.GetButtonDown(JUMP_INPUT))
        {
            playerAnimator.SetTrigger(JUMP_ANIM);
            AudioSource.PlayClipAtPoint(jumpSFX, mainCameraPos, sfxVolume);
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            playerRigidBody.velocity += jumpVelocity;
        }
    }

    private void Run()
    {
        float inputAxis = Input.GetAxis(HORIZONTAL_INPUT);
        Vector2 moveVelocity = new Vector2(inputAxis * moveSpeed, playerRigidBody.velocity.y);
        playerRigidBody.velocity = moveVelocity;

        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask(GROUND_LAYER, MOVING_PLATFORM_LAYER)))
        {
            playerAnimator.SetBool(RUNNING_ANIM, false);
        }
        else
        {
            bool hasHorizontalMovement = Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon;
            playerAnimator.SetBool(RUNNING_ANIM, hasHorizontalMovement);
        }
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
