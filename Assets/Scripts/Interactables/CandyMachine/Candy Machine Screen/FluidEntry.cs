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


}
