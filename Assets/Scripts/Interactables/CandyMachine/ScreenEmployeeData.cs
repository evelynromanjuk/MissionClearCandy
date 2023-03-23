using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenEmployeeData : MonoBehaviour
{
    public TMP_Text EmployeeName;
    public TMP_Text EmployeePassword;

    public void SetData(string name, string password)
    {
        EmployeeName.text = name;
        EmployeePassword.text = password;
    }
}
