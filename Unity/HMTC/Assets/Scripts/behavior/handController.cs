using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handController : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    public bool canMove = true;
    private bool inGrabRange = false;

    Rigidbody2D rb;
    Vector3 grabOffset;

    [SerializeField] private Transform grabPoint;
    private GameObject grabbedObject;
    private Collider2D tempCollision;
    private int targetLayer;

    public obstacleBehavior obby;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetLayer = LayerMask.NameToLayer("obstacles");
        gameObject.layer = LayerMask.NameToLayer("Default");
    }

    void Update()
    {
        if (canMove)
        {
            MoveCheck();
        }        
    }

    private void FixedUpdate()
    {
        if (inGrabRange && (tempCollision != null) && (obby.superStatic == false))
        {
            PickupFixed(tempCollision);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("the hand collided with something");
        if (collision.gameObject.layer == targetLayer)
        {
            inGrabRange = true;
            tempCollision = collision;
            obby = collision.gameObject.GetComponent<obstacleBehavior>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("stopped colliding");
        if (collision.gameObject.layer == targetLayer)
        {
            inGrabRange = false;
            tempCollision = null;
            obby = null;
        }
    }

    private void MoveCheck()
    {
        //MOVE
        horizontalMove = Input.GetAxisRaw("Horizontal1") * speed;
        verticalMove = Input.GetAxisRaw("Vertical1") * speed;
        rb.velocity = new Vector2(horizontalMove, verticalMove);
    }

    private void PickupFixed(Collider2D collision)
    {
        Debug.Log("it was an obstacle");
        if (Input.GetKey(KeyCode.Space) && grabbedObject == null)
        {
            Debug.Log("the hand is picking it up");
            anim.SetBool("Grabbing", true);

            grabbedObject = collision.gameObject;
            obby.isAwake = false;

            gameObject.layer = LayerMask.NameToLayer("hand");
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
            grabbedObject.transform.position = grabPoint.position;
            grabbedObject.transform.SetParent(transform);
        }
        else if ((Input.GetKey(KeyCode.Space) == false) && grabbedObject != null)
        {
            Debug.Log("the hand has released its claim");
            anim.SetBool("Grabbing", false);

            gameObject.layer = LayerMask.NameToLayer("Default");
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObject.transform.SetParent(null);

            obby.isAwake = true;
            grabbedObject = null;
        }
    }
}