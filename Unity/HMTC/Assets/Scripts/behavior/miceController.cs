using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miceController : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    [SerializeField] public float jumpHeight = 5f;
    bool facingRight = true;
    bool isGrounded = true;
    float horizontalMove = 0f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //MOVE
        horizontalMove = Input.GetAxisRaw("Horizontal1") * speed * Time.deltaTime;
        
        //JUMP
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("jump!");
        }

    }
}