using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMScreenManager : MonoBehaviour
{
    public Scanner Scanner;
    public CMScreen CMScreen;
    public KeypadManager KeypadManager;

    // Start is called before the first frame update
    void Start()
    {
        Scanner.SubscribeCardScanned(OnScan);
        Scanner.SubscribeCardRemoved(OnCardRemoved);
        KeypadManager.SubscribeCorrectPasswordEntered(OnPasswordEntered);
        KeypadManager.SubscribeCorrectRecipeEntered(OnCodeEntered);
        KeypadManager.SubscribeUserInputChanged(OnInputChanged);
    }

    public void SetScanner(Scanner newScanner)
    {
        Scanner = newScanner;
    }

    void OnScan(EmployeeCard card)
    {
        string employeeName = card.GetEmployeeName();
        string employeePassword = card.GetPassword();
        CMScreen.OpenSignInFrame(employeeName, employeePassword);
        KeypadManager.PasswordFrameActive(true);
    }

    void OnCardRemoved()
    {
        CMScreen.OpenDefaultFrame();
    }

    void OnPasswordEntered(bool passwordCorrect)
    {
        if(!passwordCorrect)
        {
            CMScreen.ShowPasswordError();
        }
        else
        {
            CMScreen.OpenRecipeCodeFrame();
            KeypadManager.PasswordFrameActive(false);
            KeypadManager.RecipeCodeFrameActive(true);
        }
    }

    void OnCodeEntered(bool codeCorrect)
    {
        if(!codeCorrect)
        {
            CMScreen.ShowCodeError();
        }
        else
        {
            CMScreen.OpenFillMachineFrame();
        }
    }

    void OnInputChanged(string value, bool isPassword)
    {
        CMScreen.UpdateInputData(value, isPassword);
        Debug.Log("CMScreenManager: This value is a password: " + isPassword);
    }

}
