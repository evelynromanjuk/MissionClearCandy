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
    private float _robotFontSize = 0.01f;
    private float _desktopFontSize = 20f;
    private float _currentFontSize;

    public void SetEntryData(string Name, float Current, float Goal)
    {
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

    public void SetFontSize(bool IsRobotScene)
    {
        float FontSize;
        
        if (!IsRobotScene)
        {
            FontSize = _desktopFontSize;
        }
        else
        {
            FontSize = _robotFontSize;
            Debug.Log("THIS IS A ROBOT SCENE! Font Size is now: " + FontSize + ", check, " + _robotFontSize);
        }
        FluidName.fontSize = FontSize;
        CurrentPercentage.fontSize = FontSize;
        GoalPercentage.fontSize = FontSize;

        _currentFontSize = FontSize;

    }




}
