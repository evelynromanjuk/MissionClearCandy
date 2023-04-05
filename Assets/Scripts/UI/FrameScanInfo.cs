using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FrameScanInfo : MonoBehaviour
{
    public GameObject DataEntry;
    public GameObject Container;
    private List<ScanEntry> _currentEntries = new List<ScanEntry>();

    public void PasteScanData(string[,] _scanData)
    {
        ClearData();
        for (int i = 0; i < _scanData.GetLength(0); i++)
        {
            GameObject NewEntry = Instantiate(DataEntry, Container.transform, false) as GameObject;
            ScanEntry ScanEntry = NewEntry.GetComponent<ScanEntry>();
            if(ScanEntry)
            {
                _currentEntries.Add(ScanEntry);
                ScanEntry.SetEntryData(_scanData[i, 0], _scanData[i, 1]);
            }
        }
    }

    public void ClearData()
    {
        foreach (var Entry in _currentEntries)
        {
            Destroy(Entry.gameObject);
        }
        _currentEntries.Clear();
    }
}
