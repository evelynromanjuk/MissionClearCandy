using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CMScreen : MonoBehaviour
{
    [SerializeField] private GameObject _frameSignIn;
    [SerializeField] private GameObject _frameEnterPassword;
    [SerializeField] private GameObject _frameEnterRecipeCode;
    [SerializeField] private GameObject _frameFillMachine;
    [SerializeField] private ScreenEmployeeData _screenEmployeeData;
    [SerializeField] private ScreenRecipeData _screenRecipeData;

    public void OpenDefaultFrame()
    {
        _frameEnterPassword.SetActive(false);
        _frameSignIn.SetActive(true);
    }

    public void OpenSignInFrame(string name, string password)
    {
        _frameSignIn.SetActive(false);

        _screenEmployeeData.SetData(name);
        _frameEnterPassword.SetActive(true);
    }

    public void OpenRecipeCodeFrame()
    {
        _frameEnterPassword.SetActive(false);
        _frameEnterRecipeCode.SetActive(true);
    }

    public void OpenFillMachineFrame()
    {
        _frameEnterRecipeCode.SetActive(false);
        _frameFillMachine.SetActive(true);
    }

    public void ShowPasswordError()
    {
        _screenEmployeeData.ShowPasswordError();
    }

    public void ShowCodeError()
    {
        _screenRecipeData.ShowCodeError();
    }
}
