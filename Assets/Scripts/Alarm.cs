using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    Action AlarmStarted;
    Action AlarmPaused;

    void Start()
    {
        InvokeRepeating("StartAlarm", 10, 0);
    }

    void StartAlarm()
    {
        AudioManager.Instance.Play("Alarm");
    }

    public void PauseAlarm()
    {
        AudioManager.Instance.Stop("Alarm");
        InvokeRepeating("StartAlarm", 60, 0);
    }

    public void SubscribeAlarmStarted(Action method)
    {
        AlarmStarted += method;
    }

    public void SubscribeAlarmPaused(Action method)
    {
        AlarmPaused += method;
    }
}
