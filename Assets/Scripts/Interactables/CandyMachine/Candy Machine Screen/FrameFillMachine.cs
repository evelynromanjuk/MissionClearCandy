using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FrameFillMachine : MonoBehaviour
{
    public GameObject DataEntry;
    public GameObject Container;
    public TMP_Text SuccessMessage;
    public TMP_Text Tip;
    public PlayerInteract PlayerInteract;
    public bool IsDesktopApp = false;

    private List<FluidEntry> _currentEntries = new List<FluidEntry>();
    private List<Fluid> _fluids = new List<Fluid>();
    private bool _usesTip;

    public void Initialize(bool IsRobotScene) //add to SceneManager
    {
        if (IsRobotScene)
        {
            PlayerInteract.SubscribePipeActivated(SetFontWeight);
            if(_usesTip)
            {
                Tip.gameObject.SetActive(true);
            }
        }
    }

    public void SetRobotTip(bool usesTip)
    {
        _usesTip = usesTip;
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
                FluidEntry.SetEntryData(IsDesktopApp, fluid.FluidName, fluid.CurrentPercentage, fluid.GoalPercentage);
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
