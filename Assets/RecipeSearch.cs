using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class RecipeSearch : MonoBehaviour
{
    public TMP_InputField InputField;
    public FrameFillMachine FrameFillMachine2D;
    public LogConsole LogConsole;
    public TMP_Text DefaultText;

    Action CorrectCodeEntered;

    [SerializeField]
    private string _correctCode;

    private int _subscriberCount;
    private string _warningCode = "WARNING! ERROR_2410";
    private string _warningText = ">>>Incorrect code. Recipe not found.";

    public void SubscribeCorrectCodeEntered(Action method)
    {
        CorrectCodeEntered += method;
        _subscriberCount++;
    }

    public void SearchRecipe()
    {
        string userInput = InputField.text;

        if (userInput.Equals(_correctCode))
        {
            FrameFillMachine2D.gameObject.SetActive(true);
            DefaultText.gameObject.SetActive(false);

            if(this.gameObject.GetComponent<Button>())
            {
                this.gameObject.GetComponent<Button>().interactable = false;
            }

            if(_subscriberCount > 0)
            {
                CorrectCodeEntered.Invoke();
            }
        }
        else
        {
            LogConsole.ChangeLogText(_warningCode, _warningText);
        }
    }

}
