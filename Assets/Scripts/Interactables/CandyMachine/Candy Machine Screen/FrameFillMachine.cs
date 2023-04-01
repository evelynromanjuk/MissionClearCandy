using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FrameFillMachine : MonoBehaviour
{
    public GameObject DataEntry;
    public GameObject Container;
    public TMP_Text SuccessMessage;
    private List<FluidEntry> _currentEntries = new List<FluidEntry>();

    public void PasteFluidData(List<Fluid> fluids)
    {
        foreach(var fluid in fluids)
        {
            GameObject NewEntry = Instantiate(DataEntry, Container.transform, false) as GameObject;
            FluidEntry FluidEntry = NewEntry.GetComponent<FluidEntry>();

            if(FluidEntry)
            {
                _currentEntries.Add(FluidEntry);
                FluidEntry.SetEntryData(fluid.FluidName, fluid.CurrentPercentage, fluid.GoalPercentage);
            }
        }
    }

    public void UpdateFluidData(Fluid fluid)
    {
        foreach(var fluidEntry in _currentEntries)
        {
            if(fluidEntry.GetFluidEntryName().Equals(fluid.FluidName))
            {
                fluidEntry.UpdateCurrentPercentage(fluid.CurrentPercentage);
            }
        }
    }

    public void ShowSuccessMessage()
    {
        SuccessMessage.gameObject.SetActive(true);
        Debug.Log("big success!");
    }

    //public void ClearData()
    //{
    //    foreach (var Entry in _currentEntries)
    //    {
    //        Destroy(Entry.gameObject);
    //    }
    //    _currentEntries.Clear();
    //}
}
