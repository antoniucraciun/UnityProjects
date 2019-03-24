using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour {
    #region Variables
    public PlayerSO playerData;
    //bool variables for checking if the player is on the ground or if it is facing right
    public bool isGrounded = false;
    bool facingRight = true;
    //variables used for referencing the components
    Animator anim;
    Rigidbody2D rb2d;
    //variables used for changing the the jump force or the speed
    int verticalForce = 450;
    float speed = 5f;
    int lives = 3;
    //variables used for controlling the character velocity scale and respawn position
    Vector2 velocity;
    Vector2 scale;

    public float moveHorizontal;
    #endregion
    void Awake ()
    {
        //set the references to the components
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //get the values from the data container
        verticalForce = playerData.verticalForce;
        speed = playerData.speed;
        lives = playerData.lives;
	}
    private void Update()
    {
        ManageAnimations();
    }
    void FixedUpdate ()
    {
        Strafe();
        Jump();
	}

    void Strafe()
    {
        //movement
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        if (moveHorizontal!=0)
        {
            DoMovement(moveHorizontal);
        }
        //flip the chracter so it faces the right direction
        if (moveHorizontal > 0 && !facingRight)
        {
            Flip(moveHorizontal);
        }
        else if (moveHorizontal < 0 && facingRight)
        {
            Flip(moveHorizontal);
        }
    }

    void Flip(float sign)
    {
        //flip the character so it faces the right direction
        facingRight = !facingRight;
        transform.localScale = new Vector3(1 * Mathf.Sign(sign), 1f, 1f);
    }

    void Jump()
    {
        //executes the jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
            rb2d.AddForce(Vector2.up * verticalForce);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //controlling when the character can jump
        isGrounded = true;
    }
    void DoMovement(float movement)
    {
        //executes the movement of the chracter
        rb2d.velocity = new Vector2(movement * speed, rb2d.velocity.y);
    }

    void ManageAnimations()
    {
        //manage when the player is running
        if (rb2d.velocity.y < 0.5f && rb2d.velocity.y > -0.5f || isGrounded)
        {
            anim.SetBool("isFalling", false);
            anim.SetBool("isJumping", false);
            if (rb2d.velocity.x < -0.15f || rb2d.velocity.x > 0.15f)
            {
                anim.SetBool("isRunning", true);
            }
            else if (rb2d.velocity.x >= -0.15f && rb2d.velocity.x <= 0.15f)
            {
                anim.SetBool("isRunning", false);
            }
        }
        //manage when the player is falling/jumping
        else if (rb2d.velocity.y > 0.5f || rb2d.velocity.y < -0.5f)
        {
            if (rb2d.velocity.y > 0.5f)
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isFalling", false);
            }
            if (rb2d.velocity.y < -0.5f)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isFalling", true);
            }
        }
    }

    private void OnDestroy()
    {
        lives -= 1;
    }
}
