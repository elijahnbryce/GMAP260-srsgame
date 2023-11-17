using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadZoneBehavior : MonoBehaviour
{

    
    void OnTriggerEnter2D(Collider2D co)
    {
        Debug.Log("here");
        if (co.name == "mousePlayer"){
            Destroy(co.gameObject);
            SceneManager.LoadScene(2);

        }

    }

}
