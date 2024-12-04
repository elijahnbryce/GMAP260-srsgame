using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class livesSystem : MonoBehaviour
{
    public GameObject[] lives;
    public static int life = 3;
    private EventHandler eV;


    // Start is called before the first frame update
    void Start()
    {
        eV = GetComponent<EventHandler>();
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        Destroy(lives[life].gameObject);
        if (life == 0)
        {
            if (eV != null)
            {
                eV.StartMenu();
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
