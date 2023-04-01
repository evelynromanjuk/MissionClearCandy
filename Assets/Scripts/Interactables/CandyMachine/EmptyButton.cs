using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyButton : MonoBehaviour, IInteractable
{
    public FrameFillMachine FrameFillMachine;

    private List<Fluid> _fluids = new List<Fluid>();

    public void Interact()
    {
        foreach(var entry in _fluids)
        {
            entry.CurrentPercentage = 0;
            FrameFillMachine.UpdateFluidData(entry);
        }
    }

    public void AddFluidToList(Fluid fluid)
    {
        _fluids.Add(fluid);
    }
}
