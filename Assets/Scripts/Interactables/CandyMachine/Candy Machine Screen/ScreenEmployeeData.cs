using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenEmployeeData : MonoBehaviour
{
    public TMP_Text EmployeeName;
    public TMP_Text WrongPassword;
    public TMP_InputField EnterPassword;

    public void SetData(string name)
    {
        EmployeeName.text = name;
    }

    public void ShowPasswordError()
    {
        WrongPassword.gameObject.SetActive(true);
    }

    public void UpdateUserInput(string value)
    {
        EnterPassword.text = value;
    }

}
