using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MachineSocket", menuName = "MachineSocket")]
public class MachineSocket : ScannableData
{
    public SecurityElement MachinePart;

    private string[,] _socketData;


    public override string[,] GetScanData { get => _socketData; }

    public override void CreateArray()
    {
        if (_socketData == null & MachinePart != null)
        {
            _socketData = new string[,] { { "objectType", objectType }, { "description", MachinePart.name }, { "status", MachinePart.Status } };
        }
        else
        {
            _socketData = new string[,] { { "objectType", objectType }, { "description", MachinePart.name }, { "status", MachinePart.Status } };
        }
    }

    public override void Reset()
    {
        objectType = "machine socket";
    }

}
