using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Alarm : MonoBehaviour
{
    public TMP_Text AlarmText;
    public TMP_Text EmergencyAlert;
    public TMP_Text EmergencyText;

    public Image AlarmIcon;

    private bool _alarmIsRunning;
    private float _alarmTimeRemaining = 10f;

    private bool _emergencyIsRunning;
    private float _emergencyTimeRemaining = 15f;

    void Start()
    {
        _alarmIsRunning = true;
        _emergencyIsRunning = false;
    }

    private void Update()
    {
        if(_alarmIsRunning)
        {
            CountdownAlarm();
        }
        if(_emergencyIsRunning)
        {
            CountdownEmergency();
        }
    }

    void StartAlarm()
    {
        AudioManager.Instance.Play("Alarm");

        AlarmText.gameObject.SetActive(false);
        EmergencyAlert.gameObject.SetActive(true);

        AlarmIcon.gameObject.SetActive(true);

        _emergencyIsRunning = true;
    }

    public void ResetAlarm()
    {
        AudioManager.Instance.Stop("Alarm");

        AlarmText.gameObject.SetActive(true);
        EmergencyAlert.gameObject.SetActive(false);

        AlarmIcon.gameObject.SetActive(false);

        _alarmTimeRemaining = 10f;
        _alarmIsRunning = true;

        _emergencyTimeRemaining = 15f;
    }

    private void CountdownAlarm()
    {
        if (_alarmTimeRemaining > 0)
        {
            _alarmTimeRemaining -= Time.deltaTime;
            ChangeAlarmText();
        }
        else
        {
            _alarmTimeRemaining = 0;
            ChangeAlarmText();
            _alarmIsRunning = false;
            StartAlarm();
        }
    }
    
    private void CountdownEmergency()
    {
        if (_emergencyTimeRemaining > 0)
        {
            _emergencyTimeRemaining -= Time.deltaTime;
            ChangeEmergencyText();
        }
        else
        {
            _emergencyTimeRemaining = 0;
            ChangeEmergencyText();
            _emergencyIsRunning = false;
            // TO DO: GAME OVER screen or smth when emergency timer is done
        }
    }

    private void ChangeAlarmText()
    {
        int TimeInSeconds = Mathf.RoundToInt(_alarmTimeRemaining);
        AlarmText.text = ">>> Next alarm in " + TimeInSeconds + " seconds";
    }

    private void ChangeEmergencyText()
    {
        int TimeInSeconds = Mathf.RoundToInt(_emergencyTimeRemaining);
        EmergencyText.text = ">>> Emergency shutdown in " + TimeInSeconds + " seconds";
    }

}
