using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RobotHUD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;

    // Update is called once per frame
    public void UpdateScannedObjectName(string scannedObjectName)
    {
        promptText.text = scannedObjectName;
    }
}
