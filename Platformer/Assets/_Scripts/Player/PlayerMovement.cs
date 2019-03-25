using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 400f;
    [Range(0, .3f)]
    [SerializeField] private float smoothing = .05f;

    [SerializeField] private bool airControl = false;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheckPoint;

    const float overlapRadius = .2f;
    private bool grounded;
    private bool facingRight = true;
    private bool wasCrouching = false;
    private Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = grounded;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPoint.position, overlapRadius, groundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
            }
        }
    }

    public void Move(float move, bool jump)
    {
        if (grounded || airControl)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, smoothing);
            
            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }
        }
        if (grounded && jump)
        {
            grounded = false;
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }
    
    private void Flip()
    {
        facingRight = !facingRight;
        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}