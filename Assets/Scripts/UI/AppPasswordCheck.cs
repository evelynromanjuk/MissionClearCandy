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

    [SerializeField]
    private string _password;

    public void CheckPassword()
    {
        string userInput = InputField.text;

        if(userInput.Equals(_password))
        {
            LoginFrame.SetActive(false);
            ApplicationFrame.SetActive(true);
        }
        else
        {
            ErrorMessage.gameObject.SetActive(true);
        }
    }

}
