using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadZoneBehavior : MonoBehaviour
{
    public GameObject respawnPoint;
    public GameObject player;
    
    void OnTriggerEnter2D(Collider2D co)
    {
        //Debug.Log("here");
        if (co.name == "mousePlayer"){
                        
                        
            //Destroy(co.gameObject);

            if (livesSystem.life == 0)
            {
             Destroy(co.gameObject);
            }


            player.transform.position = respawnPoint.transform.position;


            //TakeDamage(1);
            //Destroy(co.gameObject);
            //SceneManager.LoadScene(2);

        }

    }

}
