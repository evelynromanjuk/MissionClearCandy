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
    private int _robotFontSize = 6;
    private int _desktopFontSize = 20;

    public void SetEntryData(string Name, float Current, float Goal)
    {
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
        int FontSize;
        
        if (IsRobotScene)
        {
            FontSize = _desktopFontSize;
        }
        else
        {
            FontSize = _robotFontSize;  
        }
        FluidName.fontSize = FontSize;
        CurrentPercentage.fontSize = FontSize;
        GoalPercentage.fontSize = FontSize;

    }




}
