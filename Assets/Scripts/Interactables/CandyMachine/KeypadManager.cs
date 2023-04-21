using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadManager : MonoBehaviour
{
    public PlayerInteract PlayerInteract;
    public Scanner Scanner;

    Action<bool> CorrectPasswordEntered;
    Action<bool> CorrectRecipeEntered;

    private string _currentEmployeeName;
    private string _currentEmployeePassword;
    private bool _currentCardIsValid;

    private bool _passwordFrameActive;
    private bool _recipeCodeActive;

    private string _correctRecipeCode;

    private string _currentKeypadValue;

   
    void Start()
    {
        PlayerInteract.SubscribePasswordEntered(CheckUserInput);
        Scanner.SubscribeCardScanned(OnScan);

        _passwordFrameActive = false;
        _recipeCodeActive = false;

        _correctRecipeCode = "23298";
    }

    //EVENT SUBSCRIPTIONS
    public void SubscribeCorrectPasswordEntered(Action<bool> method)
    {
        CorrectPasswordEntered += method;
    }

    public void SubscribeCorrectRecipeEntered(Action<bool> method)
    {
        CorrectRecipeEntered += method;
    }

    private void OnScan(EmployeeCard card)
    {
        _currentEmployeeName = card.GetEmployeeName();
        _currentEmployeePassword = card.GetPassword();
        _currentCardIsValid = card.GetCardValidity();
    }

    private void CheckUserInput(string input)
    {
        if(_passwordFrameActive)
        {
            Debug.Log("User input is a password");
            CheckPassword(input);
        }
        else if(_recipeCodeActive)
        {
            Debug.Log("User input is a recipe code");
            CheckRecipeCode(input);
        }

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

        CorrectPasswordEntered.Invoke(isCorrect);
        _currentKeypadValue = "";
    }

    private void CheckRecipeCode(string code)
    {
        bool isCorrect = false;

        if (code == _correctRecipeCode)
        {
            isCorrect = true;
            Debug.Log("MACHINE IS WORKING :-)");
        }
        else
        {
            Debug.Log("Wrong code");
        }

        CorrectRecipeEntered.Invoke(isCorrect);
        _currentKeypadValue = "";
    }

    public void PasswordFrameActive(bool isActive)
    {
        _passwordFrameActive = isActive;
    }

    public void RecipeCodeFrameActive(bool isActive)
    {
        _recipeCodeActive = isActive;
    }

    public void UpdateKeypadValue(string value)
    {
        _currentKeypadValue += value;
        Debug.Log("Current Value: " + _currentKeypadValue);
    }

    public void EnterKeypadValue()
    {
        CheckUserInput(_currentKeypadValue);
    }

    public void ResetKeypadValues()
    {
        _currentKeypadValue = "";
    }

}
