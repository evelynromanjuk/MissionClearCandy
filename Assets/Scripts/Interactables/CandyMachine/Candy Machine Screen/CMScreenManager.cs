using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMScreenManager : MonoBehaviour
{
    public Scanner Scanner;
    public CMScreen CMScreen;
    public KeypadManager KeypadManager;
    public RecipeSearch RecipeSearch;

    private bool _codeIsExternal = false;
    private bool _loggedIn = false;

    // Start is called before the first frame update
    void Start()
    {
        Scanner.SubscribeCardScanned(OnScan);
        Scanner.SubscribeCardRemoved(OnCardRemoved);
        KeypadManager.SubscribeCorrectPasswordEntered(OnPasswordEntered);
        KeypadManager.SubscribeCorrectRecipeEntered(OnCodeEntered);
        KeypadManager.SubscribeUserInputChanged(OnInputChanged);

        if(_codeIsExternal)
        {
            RecipeSearch.SubscribeCorrectCodeEntered(OnCodeEnteredExternally);
        }
    }

    public void Initialize(bool isVersionB)
    {
        _codeIsExternal = isVersionB;
    }

    public void SetScanner(Scanner newScanner)
    {
        Scanner = newScanner;
        //Scanner.SubscribeCardScanned(OnScan);
        //Scanner.SubscribeCardRemoved(OnCardRemoved);
    }

    void OnScan(EmployeeCard card)
    {
        if(!_loggedIn)
        {
            Debug.Log("Card validity: " + card.GetCardValidity());
            if(card.GetCardValidity() == false)
            {
                CMScreen.OpenCardInvalidFrame();
                Debug.Log("Card Invalid!");
            }
            else
            {
                string employeeName = card.GetEmployeeName();
                string employeePassword = card.GetPassword();
                CMScreen.OpenSignInFrame(employeeName, employeePassword);
                KeypadManager.PasswordFrameActive(true);
            }
            
        }
        
    }

    void OnCardRemoved()
    {
        if(!_loggedIn)
        {
            CMScreen.OpenDefaultFrame();
        }
        
    }

    void OnPasswordEntered(bool passwordCorrect)
    {
        if(!passwordCorrect)
        {
            CMScreen.ShowPasswordError();
        }
        else
        {
            if(_codeIsExternal)
            {
                CMScreen.OpenWaitForDataFrame();
            }
            else
            {
                CMScreen.OpenRecipeCodeFrame();
            }
            KeypadManager.PasswordFrameActive(false);
            KeypadManager.RecipeCodeFrameActive(true);

            _loggedIn = true;
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

    void OnCodeEnteredExternally()
    {
        CMScreen.OpenFillMachineFrame();
    }

    void OnInputChanged(string value, bool isPassword)
    {
        CMScreen.UpdateInputData(value, isPassword);
        Debug.Log("CMScreenManager: This value is a password: " + isPassword);
    }

}
