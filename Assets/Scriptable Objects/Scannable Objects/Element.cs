using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Element", menuName = "Element")]
public class Element : ScannableData
{
    public new string name;
    public string periodicSymbol;
    public string ordinalNumber;

    private string[,] _elementData;


    public override string[,] GetScanData { get => _elementData; }

    public override void CreateArray()
    {
        _elementData = new string[,] { { "objectType", objectType }, { "element", name }, { "symbol", periodicSymbol }, { "ordinal number", ordinalNumber } };
    }

    public override void Reset()
    {
        objectType = "chemical element";
    }
}
