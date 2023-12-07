using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelEnd : MonoBehaviour
{
    public Canvas endCanvas;
    public miceController mouseMove;
    public handController handMove;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        //endCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //wingame
        Time.timeScale = 0;
        //endCanvas.gameObject.SetActive(true);
        mouseMove.canMove = false;
        handMove.canMove = false;

    }
}
