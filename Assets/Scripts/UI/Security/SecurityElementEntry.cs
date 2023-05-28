using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SecurityElementEntry : MonoBehaviour
{
    public TMP_Text Name;
    public TMP_Text Status;
    public TMP_Text Info;
    public Button LockButton;
    public TMP_Text LockButtonText;

    public void SetEntry(string ElementName, string ElementStatus, string ElementInfo)
    {
        Name.text = ElementName;
        Status.text = ElementStatus;
        Info.text = ElementInfo;

        if(ElementName.Contains("Door"))
        {
            LockButton.gameObject.SetActive(true);
        }
        else
        {
            LockButton.gameObject.SetActive(false);
        }
    }

    public void ActivateLockButton()
    {
        LockButton.interactable = true;
    }
}
