using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RecipeSearch : MonoBehaviour
{
    public TMP_InputField InputField;
    public FrameFillMachine FrameFillMachine2D;
    public TMP_Text DefaultText;
    public TMP_Text WarningCode;
    public TMP_Text WarningText;

    [SerializeField]
    private string _correctCode;

    public void SearchRecipe()
    {
        string userInput = InputField.text;

        if (userInput.Equals(_correctCode))
        {
            Debug.Log("Code is correct");
            FrameFillMachine2D.gameObject.SetActive(true);
            DefaultText.gameObject.SetActive(false);
            if(this.gameObject.GetComponent<Button>())
            {
                this.gameObject.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            Debug.Log("Code is not correct");
            WarningCode.text = "WARNING! ERROR_2410";
            WarningText.text = ">>>Incorrect code. Recipe not found.";
        }
    }

}
