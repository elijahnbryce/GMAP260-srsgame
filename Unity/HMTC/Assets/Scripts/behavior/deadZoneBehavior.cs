using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadZoneBehavior : MonoBehaviour
{
    public Canvas failCanvas;

    private Vector3 handSpawn;
    private Vector3 mouseSpawn;
    [SerializeField] private Transform verticalBound;
    [SerializeField] private GameObject mousePlayer;
    [SerializeField] private GameObject handPlayer;
    //public GameObject respawnPoint;
    private GameObject tempTarrg;
    private miceController mc;
    private handController hc;

    private void Start()
    {
        mc = mousePlayer.GetComponent<miceController>();
        hc = handPlayer.GetComponent<handController>();
        mouseSpawn = mousePlayer.transform.position;
        handSpawn = handPlayer.transform.position;
    }

    private void Update()
    {
    }
/*
    public void handleBounds(GameObject targ)
    {
        Debug.Log("Fell in the void");
        if (targ.tag == "Player")
        {
            if (livesSystem.life == 0)
            {
                FailLevel();
            }
        }
        if (targ.tag == "Obstacle")
        {
            tempTarrg = targ.gameObject;
            tempTarrg.transform.position = tempTarrg.GetComponent<obstacleBehavior>().spawnPoint;
        }
    }
*/
    private void FailLevel()
    {
        Time.timeScale = 0;
        mc.canMove = false;
        hc.canMove = false;
        failCanvas.gameObject.SetActive(true);
        //Destroy(targ);
        Cursor.visible = true;
    }

   private void TakeDamage(int damage)
    {
        if (livesSystem.life > 0)
        {
            livesSystem.life -= 1;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        tempTarrg = collider.gameObject;
        Debug.Log("Fell in the void");

        if (collider.tag == "Player")
        {
            if (livesSystem.life == 0)
            {
                FailLevel();
            }
            else if (livesSystem.life < 0)
            {
                if (tempTarrg.name == "mousePlayer")
                {
                    tempTarrg.transform.position = mouseSpawn;
                }
                else if (tempTarrg.name == "handPlayer")
                {
                    tempTarrg.transform.position = handSpawn;
                }
                TakeDamage(1);
            }

            //Destroy(co.gameObject);
            //SceneManager.LoadScene(2);

        }

        if (collider.tag == "Obstacle")
        {
            tempTarrg.transform.position = tempTarrg.GetComponent<obstacleBehavior>().spawnPoint;
        }

    }
 
}
