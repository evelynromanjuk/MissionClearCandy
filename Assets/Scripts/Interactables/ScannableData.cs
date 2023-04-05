using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScannableData : ScriptableObject
{
    public string objectType;

    public abstract string[,] GetScanData { get; }
    public abstract void CreateArray();
    public abstract void Reset();
}
