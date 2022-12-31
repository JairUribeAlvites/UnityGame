using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator_component;
    

    private BoxCollider2D collider_player_sprite;
    [SerializeField] private LayerMask JumpableGround;

    private float dirX = 0f;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] private AudioSource JumpSound;

    private enum MovementState { is_idle_animation, is_running_animation, is_jumping_animation, is_falling_animation };
    private MovementState state = MovementState.is_idle_animation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator_component = GetComponent<Animator>();
        collider_player_sprite = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX*moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity= new Vector2(rb.velocity.x, jumpForce);
            JumpSound.Play();
        }
        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        MovementState state;
        if(dirX > 0f)
        {
            state = MovementState.is_running_animation;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.is_running_animation;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.is_idle_animation;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.is_jumping_animation;
            //sprite.flipX = false;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.is_falling_animation;
            //sprite.flipX = true;
        }

        animator_component.SetInteger("animationdef_state", (int)state);
    }

    private bool IsGrounded()
    {
        //cast collider, duplicates the dimensions and position from the player sprite to check if it collides with the layer 'ground'
        return Physics2D.BoxCast(collider_player_sprite.bounds.center, collider_player_sprite.size, 0f, Vector2.down, .1f, JumpableGround );
    }
}
