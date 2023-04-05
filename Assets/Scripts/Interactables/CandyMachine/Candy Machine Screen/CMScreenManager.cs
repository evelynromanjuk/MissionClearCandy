using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMScreenManager : MonoBehaviour
{
    public Scanner Scanner;
    public CMScreen CMScreen;
    public FrameFillMachine FrameFillMachine;
    public KeypadManager KeypadManager;

    // Start is called before the first frame update
    void Start()
    {
        Scanner.SubscribeCardScanned(OnScan);
        Scanner.SubscribeCardRemoved(OnCardRemoved);
        KeypadManager.SubscribeCorrectPasswordEntered(OnPasswordEntered);
        KeypadManager.SubscribeCorrectRecipeEntered(OnCodeEntered);
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

}
