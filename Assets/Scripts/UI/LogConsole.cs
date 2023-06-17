using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogConsole : MonoBehaviour
{

    public TMP_Text WarningCodeField;
    public TMP_Text WarningTextField;

    public FluidCompositionManager FluidCompositionManager;
    public Lever Lever;
    public EmptyButton EmptyButton;

    private void Start()
    {
        FluidCompositionManager.SubscribeCompositionCorrectEvent(ShowCreationMessage);
        FluidCompositionManager.SubscribeGoalExceeded(ShowGoalExceededMessage);
        Lever.SubscribeSubstanceEjected(ShowEjectionMessage);
        EmptyButton.SubscribeMachineEmptied(ShowEmptiedMessage);
    }


    public void ChangeLogText(string code, string text)
    {
        WarningCodeField.text = code;
        WarningTextField.text = text;
    }

    private void ShowCreationMessage()
    {
        string code = "PROCESS COMPLETED";
        string text = ">>>Substance created successfully. Ready to eject";

        ChangeLogText(code, text);
    }

    private void ShowEjectionMessage()
    {
        string code = "SUCCESS";
        string text = ">>>Substance ejected from Candy Machine.";

        ChangeLogText(code, text);
    }

    private void ShowEmptiedMessage(Fluid fluid)
    {
        string code = "SUCCESS";
        string text = ">>>Machine was emptied successfully.";

        ChangeLogText(code, text);
    }

    private void ShowGoalExceededMessage()
    {
        string code = "WARNING! ERROR_8455";
        string text = ">>>The limit for one of the ingredients was exceeded. Please empty the tank and start production again.";

        ChangeLogText(code, text);
    }


}
