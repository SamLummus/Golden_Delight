using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public float moveSpeed = 10f;
    private float moveInput;
    //public float jumpForce = 10f;//
    private Rigidbody2D rb;
    public bool isGrounded;
    private SpriteRenderer sprite;
    private Animator anim;

    public PhysicsMaterial2D bounceMat, normalMat;
    public bool canJump = true;
    public float jumpValue = -1f;

    private enum MovementState { idle, running, jumping, falling }

    public void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Jump();

        Vector3 movement;

        if (jumpValue == 0.0f && isGrounded)
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;
        }

        //Stops the player from walking when jump is held down
        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (Input.GetAxis("Horizontal") > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }

        else if (Input.GetAxis("Horizontal") < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }

        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }

        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private void Jump()
    {
        //when jump is held and the player is grounded, the value for jump increases
        if (Input.GetButton("Jump") && isGrounded && canJump)
        {
            jumpValue += 0.01f;
            //gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0f, jumpForce));//

            //player is forced to jump if jump value is 10 or greater and if they are grounded as well
            if (jumpValue >= 10f && isGrounded)
            {
                float tempx = moveInput * moveSpeed;
                float tempy = jumpValue;
                rb.velocity = new Vector2(tempx, tempy);
                Invoke("ResetJump", 0.2f);
            }
        }

        //When jump is released, player will jump according to jump value
        if (Input.GetButtonUp("Jump"))
        {
            if (isGrounded)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    rb.velocity = new Vector2(4f, jumpValue);
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    rb.velocity = new Vector2(-4f, jumpValue);
                }
                jumpValue = 0.0f;
                Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
                transform.position += movement * Time.deltaTime * moveSpeed;
            }
            canJump = true;
        }
    }

    private void ResetJump()
    {
        canJump = false;
        jumpValue = 0;
    }
}

