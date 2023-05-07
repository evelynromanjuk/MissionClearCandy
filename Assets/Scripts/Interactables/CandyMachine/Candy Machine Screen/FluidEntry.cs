using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FluidEntry : MonoBehaviour
{
    public TMP_Text FluidName;
    public TMP_Text CurrentPercentage;
    public TMP_Text GoalPercentage;

    private string _fluidEntryName;
    private static float _robotFontSize = 0.01f;
    private static float _desktopFontSize = 20.0f;
    private static float _currentFontSize;

    public void SetEntryData(bool isDesktopApp, string Name, float Current, float Goal)
    {
        SetFontSize(isDesktopApp);

        Debug.Log("Entry data set! Font size: " + _currentFontSize);
        FluidName.text = Name + ":";
        CurrentPercentage.text = Current + "%";
        GoalPercentage.text = " / " + Goal + "%";

        _fluidEntryName = Name;
    }

    public string GetFluidEntryName()
    {
        return _fluidEntryName;
    }

    public void UpdateCurrentPercentage(float Current)
    {
        CurrentPercentage.text = Current + "%";
    }

    public void SetFontSize(bool isDesktopApp)
    {
        float FontSize;
        
        if (isDesktopApp) // -> Hacker Screen
        {
            //FontSize = _desktopFontSize;
            FontSize = _desktopFontSize;
            Debug.Log("this is not a robot scene! Font Size: " + FontSize);
        }
        else // -> Candy Machine Screen
        {
            FontSize = _robotFontSize;
            Debug.Log("THIS IS A ROBOT SCENE! Font Size is now: " + FontSize + ", check, " + _robotFontSize);
        }
        FluidName.fontSize = FontSize;
        CurrentPercentage.fontSize = FontSize;
        GoalPercentage.fontSize = FontSize;

        _currentFontSize = FontSize;

    }

    public void SetFontWeight(bool isActivated)
    {
        if(isActivated)
        {
            FluidName.fontStyle = FontStyles.Bold;
        }
        else
        {
            FluidName.fontStyle = FontStyles.Normal;
        }
    }




}
