using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    private TMP_Text timerText;
    enum TimerType {countDown, stopWatch}

    [SerializeField] private TimerType timerType;

    private bool timerTicking;


    [SerializeField] private float timerDisplay = 60.0f;

    private void EventManagertimerStart() => timerTicking = true;

    private void EventManagertimerUpdate(float value) => timerDisplay += value;

    private void EventManagertimerStop() => timerTicking = false;

    private void Start()
    {
        timerText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        EventManager.timeStart += EventManagertimerStart;
        
        EventManager.timeUpdate += EventManagertimerUpdate;


        EventManager.timeStop += EventManagertimerStop;
    }

    private void OnDisable()
    {
        EventManager.timeStart -= EventManagertimerStart;
        
        EventManager.timeUpdate -= EventManagertimerUpdate;


        EventManager.timeStop -= EventManagertimerStop;

    }


    // Update is called once per frame
    void Update()
    {

        if (!timerTicking)return;
        if (timerType == TimerType.countDown && timerDisplay < 0.0f) 
        {
            EventManager.timerStop();
            return;

        }
        timerDisplay += timerType == TimerType.countDown ? - Time.deltaTime : Time.deltaTime;

        TimeSpan timeSpan = TimeSpan.FromSeconds(timerDisplay);
        timerText.text = timeSpan.ToString(@"mm\:ss\:ff");
        
    }
}
