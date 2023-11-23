using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event UnityAction timeStop;

    public static void timerStop() => timeStop?.Invoke();


    public void OnEnable()
    {
        EventManager.timeStop += EventManagertimerStop;
    }

    private void EventManagertimerStop()
    {
        SceneManager.LoadScene(2);
        
        //Debug.Log("game over");
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.timerStart();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
