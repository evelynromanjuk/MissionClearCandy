using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannableObject : MonoBehaviour
{
    [SerializeField] private ScannableData _scanData;

    private string[,] _dataArray;

    public void Start()
    {
        _scanData.CreateArray();
        _dataArray = _scanData.GetScanData;
    }

    public void Interact()
    {
        Debug.Log("You interacted with: " + this.name);
        if(_scanData != null)
        {
            for(int i = 0; i < (_dataArray.GetLength(0)); i++)
            {
                Debug.Log(_dataArray[i, 0] + ": " + _dataArray[i, 1]);
            }
        }
        else
        {
            Debug.Log("No data could not be fetched.");
        }
    }
}
