using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CMScreen : MonoBehaviour
{
    [SerializeField] private GameObject _frameSignIn;
    [SerializeField] private GameObject _frameEnterPassword;
    [SerializeField] private ScreenEmployeeData _screenEmployeeData;

    public void OpenSignInFrame(string name, string password)
    {
        _frameSignIn.SetActive(false);

        _screenEmployeeData.SetData(name, password);
        _frameEnterPassword.SetActive(true);
    }
}
