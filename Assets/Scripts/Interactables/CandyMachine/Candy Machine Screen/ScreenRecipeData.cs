using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenRecipeData : MonoBehaviour
{
    public TMP_Text WrongCode;
    public TMP_InputField EnterRecipeCode;

    public void ShowCodeError()
    {
        WrongCode.gameObject.SetActive(true);
    }

    public void UpdateUserInput(string value)
    {
        EnterRecipeCode.text = value;
    }

}
