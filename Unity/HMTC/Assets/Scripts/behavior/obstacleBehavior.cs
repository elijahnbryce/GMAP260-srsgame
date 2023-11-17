using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleBehavior : MonoBehaviour
{
    Vector3 grabOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collider)
    {
        //if (tag == 'Interactable') then Interact(collider);
        //INTERACT (GRAB)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Trying to interact!");
            //TODO only trigger while in radius
            //collider trigger 
            thisBehavior(collider);
        }
    }

    private void thisBehavior(Collider collider)
    {
        GameObject target = collider.gameObject;
        grabOffset = transform.position - target.transform.position;
        transform.position = target.transform.position + grabOffset;
    }
}
