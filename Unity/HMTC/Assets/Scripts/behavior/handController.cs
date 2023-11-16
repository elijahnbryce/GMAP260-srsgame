using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handController : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    [SerializeField] public float jumpHeight = 5f;
    bool facingRight = true;
    float horizontalMove = 0f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //MOVE
        horizontalMove = Input.GetAxisRaw("Horizontal2") * speed * Time.deltaTime;

        //INTERACT (GRAB)
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Trying to interact!");
            //TODO only trigger while in radius
                //collider trigger 
        }
    }
}
