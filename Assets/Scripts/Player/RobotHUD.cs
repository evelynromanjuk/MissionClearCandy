using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RobotHUD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scannedObjectField;

    // Update is called once per frame
    public void UpdateScannedObjectName(string scannedObjectName)
    {
        scannedObjectField.text = scannedObjectName;
    }
}
