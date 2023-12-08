using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleBehavior : MonoBehaviour
{
    Vector3 grabOffset;
    //bool isHeld = false;
    //[SerializeField] GameObject theHand;
    //[SerializeField] Transform testPos;
    public Vector3 spawnPoint;
    public Quaternion spawnRot;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private float clippingCheckRadius = 0.1f;

    public Collider2D boxCollider;
    private Rigidbody2D rb;
    public bool isAwake;
    public bool wasStatic;
    public bool doesNotFall;
    public bool superStatic;

    void Start()
    {
        //handControl = theHand.GetComponent<handController>();

        rb = GetComponent<Rigidbody2D>();
        isAwake = true;
        wasStatic = (rb.bodyType == RigidbodyType2D.Static);
        spawnPoint = rb.transform.position;
        spawnRot = rb.transform.rotation;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (isAwake)
        {
            if (IsGrounded(groundCheck, clippingCheckRadius, groundLayer))
            {
                //rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y + .1f, rb.transform.position.z);
            }
            if (IsGrounded(groundCheck, groundCheckRadius, groundLayer))
            {
                if (wasStatic)
                {
                    rb.bodyType = RigidbodyType2D.Static;
                }
            }
            if (isAwake && doesNotFall)
            {
                rb.bodyType = RigidbodyType2D.Static;
            }
        }
        else if (!isAwake)
        {
        }
    }

    public bool CheckOnGround()
    {
        return IsGrounded(groundCheck, groundCheckRadius, groundLayer);
    }

    private bool IsGrounded(Transform t, float r, LayerMask l)
    {
        return Physics2D.OverlapCircle(t.position, r, l);
    }
}
