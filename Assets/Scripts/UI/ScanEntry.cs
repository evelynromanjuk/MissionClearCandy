using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScanEntry : MonoBehaviour
{
    public TMP_Text PropertyTitle;
    public TMP_Text PropertyValue;

    public void SetEntryData(string Title, string Value)
    {
        PropertyTitle.text = Title + ": ";
        PropertyValue.text = Value;
    }
}
