using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameFillMachine : MonoBehaviour
{
    public GameObject DataEntry;
    public GameObject Container;

    public void PasteFluidData(List<Fluid> fluids)
    {
        foreach(var fluid in fluids)
        {
            GameObject NewEntry = Instantiate(DataEntry, Container.transform, false) as GameObject;
            FluidEntry FluidEntry = NewEntry.GetComponent<FluidEntry>();

            if(FluidEntry)
            {
                FluidEntry.SetEntryData(fluid.FluidName, fluid.CurrentPercentage, fluid.GoalPercentage);
            }
        }
    }
}
