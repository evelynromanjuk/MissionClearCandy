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
    public TMP_Text DefaultText;
    public TMP_Text WarningCode;
    public TMP_Text WarningText;

    Action CorrectCodeEntered;

    [SerializeField]
    private string _correctCode;

    private int _subscriberCount;

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
            WarningCode.text = "WARNING! ERROR_2410";
            WarningText.text = ">>>Incorrect code. Recipe not found.";
        }
    }

}
