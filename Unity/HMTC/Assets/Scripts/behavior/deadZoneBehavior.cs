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

    [SerializeField] private Transform boundX, boundY;
    private Vector2 bounds;

    private void Start()
    {
        Time.timeScale = 1;
        mc = mousePlayer.GetComponent<miceController>();
        hc = handPlayer.GetComponent<handController>();
        mouseSpawn = mousePlayer.transform.position;
        handSpawn = handPlayer.transform.position;

        livesS = GetComponent<livesSystem>();

        bounds = new Vector2 (Mathf.Abs(boundX.position.x), Mathf.Abs(boundY.position.y));
        mc.canMove = true;
        hc.canMove = true;
    }

    private void Update()
    {
        showLives = livesSystem.life;
    }

    private void FailLevel()
    {
        Time.timeScale = 0;
        //failCanvas.gameObject.SetActive(true);
        //Destroy(targ);
        Cursor.visible = true;
        Debug.Log("Level failed");
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (!BeyondBounds(collider.transform)) return;

        tempTarrg = collider.gameObject;
        Debug.Log(collider.gameObject.name + "Fell in the void");

        if (collider.tag == "Player")
        {
            tempTarrg.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            Debug.Log("player in void -- with " + livesSystem.life + " lives");
            if (livesSystem.life == 0)
            {
                FailLevel();
            }
            else
            {
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
        }

        if (collider.gameObject.layer == 8)
        {
            if (collider.gameObject.GetComponent<obstacleBehavior>().CheckOnGround() == false)
            {
                tempTarrg.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                tempTarrg.transform.rotation = tempTarrg.GetComponent<obstacleBehavior>().spawnRot;
                tempTarrg.transform.position = tempTarrg.GetComponent<obstacleBehavior>().spawnPoint;
            }
        }

    }
    private bool BeyondBounds(Transform t)
    {
        return (Mathf.Abs(t.position.x) > bounds.x || Mathf.Abs(t.position.y) > bounds.y);
    }
}
