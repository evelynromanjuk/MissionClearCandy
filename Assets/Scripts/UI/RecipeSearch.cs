using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class RecipeSearch : MonoBehaviour
{
    public KeypadManager KeypadManager;
    public TMP_InputField InputField;
    public FrameFillMachine FrameFillMachine2D;
    public LogConsole LogConsole;
    public TMP_Text DefaultText;

    Action CorrectCodeEntered;

    [SerializeField]
    private string _correctCode;
    private int _subscriberCount;

    //private void Start()
    //{
    //    KeypadManager.SubscribeCorrectPasswordEntered(EnableButton);
    //}

    public void Initialize()
    {
        KeypadManager.SubscribeCorrectPasswordEntered(EnableButton);
    }

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
                Debug.Log("Recipe Search: Correct code entered");
                CorrectCodeEntered.Invoke();
            }
            LogConsole.ChangeLogText("SUCCESS", ">>>Recipe code: 144026 found.");
        }
        else
        {
            LogConsole.ChangeLogText("WARNING! ERROR_2410", ">>>Incorrect code. Recipe not found.");
        }
    }

    private void EnableButton(bool isCorrect)
    {
        if (this.gameObject.GetComponent<Button>() & isCorrect)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }
    }

}
