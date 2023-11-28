using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void StartGame()
    {
        livesSystem.life = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

    }

    public void replay()
    {
        livesSystem.life = 3;
        SceneManager.LoadScene(1);
    }


    public void startMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void QuitGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
