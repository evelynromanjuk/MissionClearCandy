using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipe : ScannableData
{
    public string color;
    public string goalPercentage;

    private string[,] _recipeData;


    public override void CreateArray()
    {
        _recipeData = new string[,] { {"objectType", objectType }, { "color", color }, {"goalPercentage", goalPercentage} };

        Debug.Log("object: " + this.name + ", array size: " + _recipeData.GetLength(0));
    }

    public override string[,] GetScanData { get => _recipeData; }

    public override void Reset()
    {
        objectType = "recipe";
    }
}
