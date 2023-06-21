using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePart : MonoBehaviour
{
    public SecurityElement _machinePart;
    public PlayerInteract PlayerInteract;

    private static bool _isScanned = false;

    private void Start()
    {
        if (PlayerInteract != null)
        {
            PlayerInteract.SubscribeObjectScanned(SetIsScanned);
            PlayerInteract.SubscribeEnvironmentScanned(ShowOutline);
        }
    }

    public void UpdateMachinePart(bool isActive)
    {
        _machinePart.SetActive(isActive);
    }

    public bool IsActive()
    {
        return _machinePart.IsActive;
    }

    void ShowOutline(bool isScanned)
    {

        if (_isScanned & gameObject.GetComponent<Outline>() != null)
        {
            if(isScanned)
            {
                gameObject.GetComponent<Outline>().SetHackerActivated(true);
                gameObject.GetComponent<Outline>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Outline>().SetHackerActivated(true);
                gameObject.GetComponent<Outline>().enabled = false;
            }
        }
    }

    void SetIsScanned(string[,] data)
    {
        _isScanned = true;
    }
}
