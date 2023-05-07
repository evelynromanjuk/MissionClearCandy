using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FrameFillMachine : MonoBehaviour
{
    public GameObject DataEntry;
    public GameObject Container;
    public TMP_Text SuccessMessage;
    public PlayerInteract PlayerInteract;
    private List<FluidEntry> _currentEntries = new List<FluidEntry>();
    private List<Fluid> _fluids = new List<Fluid>();

    public void Initialize(bool IsRobotScene) //add to SceneManager
    {
        if (IsRobotScene)
        {
            Debug.Log("FrameFillMachine subscribed to PlayerInteract method");
            PlayerInteract.SubscribePipeActivated(SetFontWeight);
        }
    }

    public void PasteFluidData(List<Fluid> fluids)
    {
        _fluids = fluids;
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
        FluidEntry fluidEntry = FindFluidEntry(fluid);
        fluidEntry.UpdateCurrentPercentage(fluid.CurrentPercentage);

        //foreach(var fluidEntry in _currentEntries)
        //{
        //    if(fluidEntry.GetFluidEntryName().Equals(fluid.FluidName))
        //    {
        //        fluidEntry.UpdateCurrentPercentage(fluid.CurrentPercentage);
        //    }
        //}
    }

    public void SetFontWeight(string key, bool isActivated)
    {
        FluidEntry fluidEntry;
        foreach(var fluid in _fluids)
        {
            fluidEntry = FindFluidEntry(fluid);
            if(fluid.Key.Equals(key))
            {
                Debug.Log("I found the right key in my fluids list: " + key);
                fluidEntry.SetFontWeight(isActivated);
            }
            else
            {
                Debug.Log("Key not found: " + fluid.Key + ", " + key);
                //current fluid in list is not equal to the key that was pressed
                //the fluid entry needs to be font weight normal
                fluidEntry.SetFontWeight(false);
            }
            
        }
    }

    private FluidEntry FindFluidEntry(Fluid fluid)
    {
        FluidEntry foundEntry = null;
        foreach(var fluidEntry in _currentEntries)
        {
            if(fluidEntry.GetFluidEntryName().Equals(fluid.FluidName))
            {
                foundEntry = fluidEntry;
            }
        }

        return foundEntry;
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
