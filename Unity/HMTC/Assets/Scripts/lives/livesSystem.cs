using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class livesSystem : MonoBehaviour
{
    public GameObject[] lives;
    public static int life = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (life < 1)
        {
            Destroy(lives[0].gameObject);

        }else if (life <2)
        {
            Destroy(lives[1].gameObject);
        }
        else if (life < 3)
        {
            Destroy(lives[2].gameObject);
        }
        
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        if (life == 0)
        {
            SceneManager.LoadScene(2);
            
        }
    }


        void OnTriggerEnter2D(Collider2D co)
    {
        //Debug.Log("here");
        if (co.name == "deadZone"){

            TakeDamage(1);

            //Destroy(co.gameObject);
            //SceneManager.LoadScene(2);

        }


    }




}
