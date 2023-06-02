using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EncryptedNote", menuName = "EncprytedNote")]
public class EncryptedNote : ScannableData
{
    public string description;
    public string info1;
    public string info2;
    public string info3;

    private string[,] _noteData;

    public override string[,] GetScanData { get => _noteData; }

    public override void CreateArray()
    {
        if (_noteData == null)
        {
            _noteData = new string[,] { { "description", description }, { "symbol 1", info1 }, { "symbol 2", info2 }, { "symbol 3", info3 } };
        }
    }

    public override void Reset()
    {
        objectType = "note";
    }
}
