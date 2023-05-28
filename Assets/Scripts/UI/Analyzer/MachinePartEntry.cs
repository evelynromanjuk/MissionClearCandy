using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MachinePartEntry : MonoBehaviour
{
    public TMP_Text Description;
    public TMP_Text Status;
    public TMP_Text Info;

    public void SetEntry(string PartName, string PartStatus, string PartInfo)
    {
        Description.text = PartName;
        Status.text = PartStatus;
        Info.text = PartInfo;
    }
}
