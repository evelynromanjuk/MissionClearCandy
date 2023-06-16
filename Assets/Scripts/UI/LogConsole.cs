using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogConsole : MonoBehaviour
{

    public TMP_Text WarningCodeField;
    public TMP_Text WarningTextField;

    public FluidCompositionManager FluidCompositionManager;

    private void Start()
    {
        FluidCompositionManager.SubscribeCompositionCorrectEvent(ShowSuccessMessage);
    }


    public void ChangeLogText(string code, string text)
    {
        WarningCodeField.text = code;
        WarningTextField.text = text;
    }

    private void ShowSuccessMessage()
    {
        string code = "PROCESS COMPLETED";
        string text = ">>>Substance created successfully. Ready to eject";

        ChangeLogText(code, text);
    }
}
