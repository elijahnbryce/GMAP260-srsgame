using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handController : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    private float horizontalMove = 0f;
    private float verticalMove = 0f;

    Rigidbody2D rb;
    Vector3 grabOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //MOVE
        horizontalMove = Input.GetAxisRaw("Horizontal1") * speed;
        verticalMove = Input.GetAxisRaw("Vertical1") * speed;
        rb.velocity = new Vector2(horizontalMove, verticalMove);

    }

    void OnTriggerStay2D(Collider2D collider)
    {
        //if (tag == 'Interactable') then Interact(collider);
        //INTERACT (GRAB)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Trying to interact!");
            //TODO only trigger while in radius
            //collider trigger 
            //Pickup(collider);
        }
    }

    private void Pickup(Collider2D collider)
    {
        GameObject target = collider.gameObject;
        grabOffset = transform.position - target.transform.position;
        target.transform.position = transform.position - grabOffset;
    }
} 
