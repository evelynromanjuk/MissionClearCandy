using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EmptyButton : MonoBehaviour, IInteractable
{
    //public FrameFillMachine FrameFillMachine;

    Action<Fluid> MachineEmptied;

    private List<Fluid> _fluids = new List<Fluid>();

    public void SubscribeMachineEmptied(Action<Fluid> method)
    {
        MachineEmptied += method;
    }

    public void Interact()
    {
        foreach (var entry in _fluids)
        {
            entry.CurrentPercentage = 0;
            //FrameFillMachine.UpdateFluidData(entry);
            MachineEmptied.Invoke(entry);
        }
    }

    public void AddFluidToList(Fluid fluid) // TODO: remove later if not needed
    {
        _fluids.Add(fluid);
    }
}
