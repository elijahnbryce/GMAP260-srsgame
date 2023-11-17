using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleBehavior : MonoBehaviour
{
    Vector3 grabOffset;
    bool isHeld = false;
    [SerializeField] GameObject theHand;
    [SerializeField] Transform testPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isHeld)
        {
            grabOffset = theHand.transform.position - transform.position;
            transform.position = theHand.transform.position - grabOffset;
        }*/
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        //if (tag == 'Interactable') then Interact(collider);
        //INTERACT (GRAB)
        Debug.Log("Something is in Obstacle Collider");
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Something is trying to interact!");
            if (isHeld)
            {
                isHeld = false;
            }
            else
            {
                isHeld = true;
            }
            //TODO only trigger while in radius
            //collider trigger 
            //thisBehavior(collider);
            //transform.position = theHand.transform.position;
        }
    }

    private void thisBehavior(Collider2D collider)
    {
        GameObject target = collider.gameObject;
        grabOffset = target.transform.position - transform.position;
        transform.position = target.transform.position - grabOffset;
    }
}
