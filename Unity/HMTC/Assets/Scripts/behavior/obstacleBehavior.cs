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
    [SerializeField] private float checkRadius = 0.2f;
    private Rigidbody2D rb;
    public bool isAwake;

    void Start()
    {
        //handControl = theHand.GetComponent<handController>();
        rb = GetComponent<Rigidbody2D>();
        isAwake = true;
    }

    void Update()
    {
        if (IsGrounded() && isAwake)
        {
            rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y + .1f, rb.transform.position.z);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }
}
