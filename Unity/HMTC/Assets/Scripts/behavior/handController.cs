using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class handController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] public float speed = 5f;
    private float horizontalMove, verticalMove;
    public bool canMove = true;

    private Rigidbody2D rb;
    private Vector3 grabOffset;

    [Header("Grab")]
    [SerializeField] private Transform grabPoint;
    [SerializeField] private float grabRange = .64f;

    [SerializeField] private LayerMask targetLayer;
    
    private GameObject grabbedObject;
    private Collider2D[] hit = new Collider2D[7]; // arbitrary

    public obstacleBehavior obby;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            MoveCheck();
            GrabCheck();
        }        
    }

    private void MoveCheck()
    {
        //MOVE
        horizontalMove = Input.GetAxisRaw("Horizontal1") * speed;
        verticalMove = Input.GetAxisRaw("Vertical1") * speed;
        rb.velocity = new Vector2(horizontalMove, verticalMove);
    }

    private void GrabCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grabbedObject == null)
        {
            int tagged = Physics2D.OverlapCircleNonAlloc(transform.position, grabRange, hit, targetLayer);
            if (tagged > 0)
            {
                float dis = 0f;
                Collider2D c, tempCollision = null;
                for (int i = 0; i < tagged; i++)
                {
                    c = hit[i];
                    float cd = Vector2.Distance(grabPoint.position, c.gameObject.transform.position);
                    if (cd < dis || tempCollision == null)
                    {
                        tempCollision = c;
                        dis = cd;
                    }
                }
                PickupFixed(tempCollision);
                //System.Array.Clear(hit, 0, 7); don't need... for now
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, grabRange);
    }

    private void PickupFixed(Collider2D collision)
    {
        Debug.Log("the hand is picking it up");
        anim.SetBool("Grabbing", true);

        grabbedObject = collision.gameObject;

        //Physics2D.IgnoreCollision(collision, myCollider, true);
        grabbedObject.GetComponent<obstacleBehavior>().SetGrabbed(transform, grabPoint);

        StartCoroutine(WaitForRelease());
    }

    private IEnumerator WaitForRelease()
    {
        yield return new WaitWhile( ()=> Input.GetKey(KeyCode.Space) );
        ReleaseFixed();
    }

    private void ReleaseFixed()
    {
        Debug.Log("the hand has released its claim");
        anim.SetBool("Grabbing", false);

        //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), myCollider, false);
        grabbedObject.GetComponent<obstacleBehavior>().SetReleased();
        grabbedObject = null;
    }
}