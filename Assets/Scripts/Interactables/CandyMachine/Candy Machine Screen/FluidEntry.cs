using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FluidEntry : MonoBehaviour
{
    public TMP_Text FluidName;
    public TMP_Text CurrentPercentage;
    public TMP_Text GoalPercentage;

    public void SetEntryData(string Name, float Current, float Goal)
    {
        FluidName.text = Name + ":";
        CurrentPercentage.text = Current + "%";
        GoalPercentage.text = " / " + Goal + "%";
    }


}
