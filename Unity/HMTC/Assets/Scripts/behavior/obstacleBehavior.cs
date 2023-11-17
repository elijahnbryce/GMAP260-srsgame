using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleBehavior : MonoBehaviour
{
    Vector3 grabOffset;
    bool isHeld = false;
    [SerializeField] GameObject theHand;
    [SerializeField] Transform testPos;
    public handController handControl;
    [SerializeField] private int handLayer;

    void Start()
    {
        handControl = theHand.GetComponent<handController>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Something is in Obstacle Collider");
        if (collider.gameObject.layer == handLayer)
        {
            handControl.inGrabRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Something is in Obstacle Collider");
        if (collider.gameObject.layer == handLayer)
        {
            handControl.inGrabRange = false;
        }
    }

    private void thisBehavior(Collider2D collider)
    {
        GameObject target = collider.gameObject;
        grabOffset = target.transform.position - transform.position;
        transform.position = target.transform.position - grabOffset;
    }
}
