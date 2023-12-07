using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadZoneBehavior : MonoBehaviour
{
    public Canvas failCanvas;

    public Vector3 handSpawn;
    public Vector3 mouseSpawn;
    public int showLives;

    [SerializeField] private GameObject mousePlayer;
    [SerializeField] private GameObject handPlayer;
    public livesSystem livesS;
    private GameObject tempTarrg;
    private miceController mc;
    private handController hc; 

    private void Start()
    {
        mc = mousePlayer.GetComponent<miceController>();
        hc = handPlayer.GetComponent<handController>();
        mouseSpawn = mousePlayer.transform.position;
        handSpawn = handPlayer.transform.position;

        livesS = GetComponent<livesSystem>();
    }

    private void Update()
    {
        showLives = livesSystem.life;
    }

    private void FailLevel()
    {
        Time.timeScale = 0;
        mc.canMove = false;
        hc.canMove = false;
        failCanvas.gameObject.SetActive(true);
        //Destroy(targ);
        Cursor.visible = true;
        Debug.Log("Level failed");
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        tempTarrg = collider.gameObject;
        Debug.Log(collider.gameObject.layer + "Fell in the void");

        if (collider.tag == "Player")
        {
            Debug.Log("player in void -- with " + livesSystem.life + " lives");
            if (livesSystem.life == 0)
            {
                FailLevel();
            }
            else // (livesSystem.life < 0)
            {
                //Debug.Log("Did not fail");
                if (tempTarrg.name == "mousePlayer")
                {
                    Debug.Log("respawn mouse");
                    tempTarrg.transform.position = mouseSpawn;
                }
                else if (tempTarrg.name == "handPlayer")
                {
                    Debug.Log("respawn hand");
                    tempTarrg.transform.position = handSpawn;
                }
                livesS.TakeDamage(1);
            }

            //Destroy(co.gameObject);
            //SceneManager.LoadScene(2);

        }

        if (collider.gameObject.layer == 8)
        {
            if (collider.gameObject.GetComponent<obstacleBehavior>().CheckOnGround() == false)
            {
                tempTarrg.transform.position = tempTarrg.GetComponent<obstacleBehavior>().spawnPoint;
            }
        }

    }

}
