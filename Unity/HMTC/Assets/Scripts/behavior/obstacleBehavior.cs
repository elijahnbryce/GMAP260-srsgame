using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleBehavior : MonoBehaviour
{
    Vector3 grabOffset;
    //bool isHeld = false;
    //[SerializeField] GameObject theHand;
    //[SerializeField] Transform testPos;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private float clippingCheckRadius = 0.1f;

    private Rigidbody2D rb;
    public bool isAwake;
    private bool wasStatic;
    public bool doesNotFall;

    void Start()
    {
        //handControl = theHand.GetComponent<handController>();
        rb = GetComponent<Rigidbody2D>();
        isAwake = true;
        wasStatic = (rb.bodyType == RigidbodyType2D.Static);

    }

    void Update()
    {
        if (isAwake)
        {
            if(IsGrounded(groundCheck, clippingCheckRadius, groundLayer))
            {
                rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y + .1f, rb.transform.position.z);
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
    }

    private bool IsGrounded(Transform t, float r, LayerMask l)
    {
        return Physics2D.OverlapCircle(t.position, r, l);
    }
}
