using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miceController : MonoBehaviour
{
    [SerializeField] private Transform verticalBound;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] public float speed = 5f;
    [SerializeField] public float jumpHeight = 5f;
    bool facingRight = true;
    bool isGrounded = true;
    float horizontalMove = 0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //MOVE
        horizontalMove = Input.GetAxisRaw("Horizontal2");
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        //LOOK DIRECTION
        FlipSprite();

        //JUMP
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);
        }

        //VerticalDeath
        checkVert();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    private void FlipSprite()
    {
        if (facingRight && horizontalMove < 0f || !facingRight && horizontalMove > 0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void checkVert()
    {
        if (transform.position.y < verticalBound.position.y)
        {
            Debug.Log("Fell in the void");
            //TODO: end game, freeze time, call game over screen, destroy game object
        }
    }
}