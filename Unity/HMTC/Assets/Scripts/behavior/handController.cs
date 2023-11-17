using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handController : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    public bool canMove = true;

    Rigidbody2D rb;
    Vector3 grabOffset;

    [SerializeField] private Transform grabPoint;
    private GameObject grabbedObject;
    private int targetLayer;
    public bool inGrabRange;

    public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        //anim.SetTrigger("Idle");
        targetLayer = LayerMask.NameToLayer("obstacles");
    }

    void Update()
    {
        if (canMove)
        {
            MoveCheck();
        }

        if (inGrabRange)
        {
            StartGrab();
        }

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("the hand collided with something");
        if(collision.gameObject.layer == targetLayer)
        {
            Debug.Log("it was an obstacle");
            if (Input.GetKeyDown(KeyCode.Space) && grabbedObject == null)
            {
                Debug.Log("the hand is picking it up");
                grabbedObject = collision.gameObject;
                //grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
            }
            else if (Input.GetKeyDown(KeyCode.Space) && grabbedObject != null)
            {
                Debug.Log("the hand has released its claim");
                //grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }
        }
    }

    private void MoveCheck()
    {
        //MOVE
        horizontalMove = Input.GetAxisRaw("Horizontal1") * speed;
        verticalMove = Input.GetAxisRaw("Vertical1") * speed;
        rb.velocity = new Vector2(horizontalMove, verticalMove);
    }

    private void StartGrab()
    {
        Debug.Log("the hand is trying to grab");
        //anim.SetTrigger("Holding");
    }

    private void Drop()
    {
        Debug.Log("the hand let go of it's claim");
        //anim.SetTrigger("Idle");
    }
    private void Pickup(Collider2D collider)
    {
        GameObject target = collider.gameObject;
        grabOffset = transform.position - target.transform.position;
        target.transform.position = transform.position - grabOffset;
    }
} 
