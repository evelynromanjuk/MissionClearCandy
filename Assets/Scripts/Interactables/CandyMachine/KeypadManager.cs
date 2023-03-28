using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadManager : MonoBehaviour
{
    public PlayerInteract PlayerInteract;
    public Scanner Scanner;

    private string _currentEmployeeName;
    private string _currentEmployeePassword;
    private bool _currentCardIsValid;

   
    void Start()
    {
        PlayerInteract.SubscribePasswordEntered(CheckPassword);
        Scanner.Subscribe(OnScan);
    }

    private void OnScan(EmployeeCard card)
    {
        _currentEmployeeName = card.GetEmployeeName();
        _currentEmployeePassword = card.GetPassword();
        _currentCardIsValid = card.GetCardValidity();
    }

    private void CheckPassword(string password)
    {
        bool isCorrect = false;

        if(password == _currentEmployeePassword & _currentCardIsValid)
        {
            isCorrect = true;
            Debug.Log("WELCOME TO CANDY MACHINE APP");
        }
        else
        {
            Debug.Log("Login failed");
        }
    }

}
