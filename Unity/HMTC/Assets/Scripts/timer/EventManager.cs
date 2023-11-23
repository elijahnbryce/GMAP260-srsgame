using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static event UnityAction timeStart;
    public static event UnityAction<float> timeUpdate;
    public static event UnityAction timeStop;

    public static void timerStart() => timeStart?.Invoke();
    public static void timerStop() => timeStop?.Invoke();
    public static void timerUpdate(float value) => timeUpdate?.Invoke(value);

}
