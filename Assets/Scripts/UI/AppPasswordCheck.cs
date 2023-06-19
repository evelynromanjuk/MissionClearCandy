using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppPasswordCheck : MonoBehaviour
{

    public TMP_InputField InputField;
    public GameObject ApplicationFrame;
    public GameObject LoginFrame;
    public TMP_Text ErrorMessage;
    public Alarm Alarm;

    [SerializeField]
    private string _password;

    [SerializeField]
    private bool _isHacker3000Login = false;

    public void CheckPassword()
    {
        string userInput = InputField.text.ToUpper();

        if(userInput.Equals(_password.ToUpper()))
        {
            LoginFrame.SetActive(false);
            ApplicationFrame.SetActive(true);

            if (_isHacker3000Login)
            {
                Alarm.InitializeAlarm();
            }
        }
        else
        {
            ErrorMessage.gameObject.SetActive(true);
        }


    }

}
