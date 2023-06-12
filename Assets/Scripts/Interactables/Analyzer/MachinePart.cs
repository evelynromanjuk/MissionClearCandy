using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePart : MonoBehaviour
{
    public SecurityElement _machinePart;

    private void Start()
    {
    }

    public void UpdateMachinePart(bool isActive)
    {
        _machinePart.SetActive(isActive);
    }

    public bool IsActive()
    {
        return _machinePart.IsActive;
    }
}
