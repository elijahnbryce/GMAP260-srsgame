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
    public bool canMove = true;
    //bool isGrounded = true;
    float horizontalMove = 0f;

    private Rigidbody2D rb;

    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        //anim.SetTrigger("Idle");
    }

    void Update()
    {
        if (canMove)
        {
            MoveCheck();
        }

        //VerticalDeath
        checkVert();
    }

    private void MoveCheck()
    {
        //MOVE
        horizontalMove = Input.GetAxisRaw("Horizontal2");
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        if (horizontalMove != 0)
        {
            //anim.SetTrigger("Moving");
        }
        else
        {
            //anim.SetTrigger("Idle");
        }
        //LOOK DIRECTION
        FlipSprite();

        //JUMP
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            //anim.SetTrigger("Jumping");
        }
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
            Time.timeScale = 0;
            //TODO: end game, freeze time, call game over screen, destroy game object
        }
    }
}