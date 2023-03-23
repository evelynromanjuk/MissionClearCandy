using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeCard : MonoBehaviour
{
    [SerializeField] private Employee _employeeData;

    private string[,] _dataArray;

    private string _employeeName;
    private string _password;

    [SerializeField] private bool _isValid;

    public void Start()
    {
        _employeeData.CreateArray();
        _dataArray = _employeeData.GetScanData;

        _employeeName = _employeeData.name;
        _password = _employeeData.password;
    }

    public string GetEmployeeName()
    {
        return _employeeName;
    }

    public string GetPassword()
    {
        return _password;
    }

    public bool GetCardValidity()
    {
        return _isValid;
    }


}
