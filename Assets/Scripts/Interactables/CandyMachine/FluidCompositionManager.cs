using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidCompositionManager : MonoBehaviour
{
    public FrameFillMachine FrameFillMachine;

    private List<Fluid> _fluids = new List<Fluid>();
    Action<float> FluidAmountChanged;
    Action CompositionCorrectEvent;

    private float totalPercentage = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Paste Fluid Data!!");
        FrameFillMachine.PasteFluidData(_fluids);   
    }

    public void AddFluidToList(Fluid fluid)
    {
        _fluids.Add(fluid);
        Debug.Log("Added Fluid: " + fluid.FluidName);
    }

    public bool AddFluid(Fluid fluid, float percentage)
    {
        bool tankIsFull = false;

        if((totalPercentage + percentage) <= 100) //if tank will not be 100% full
        {
            fluid.CurrentPercentage += percentage;
            totalPercentage += percentage;
            FrameFillMachine.UpdateFluidData(fluid);

            if(fluid.CurrentPercentage == fluid.GoalPercentage)
            {
                Debug.Log("Percentage goal reached.");
                fluid.ReachedGoal = true;
                CheckComposition();
            }
            if(fluid.CurrentPercentage > fluid.GoalPercentage)
            {
                Debug.Log("Percentage goal was crossed.");
                fluid.ReachedGoal = false;
            }
        }
        else
        {
            Debug.Log("FCM: Tank is full!");
            tankIsFull = true;
        }
        return tankIsFull;
    }

    void CheckComposition()
    {
        bool compositionCorrect = false;

        foreach(var entry in _fluids)
        {
            if(entry.ReachedGoal == false)
            {
                compositionCorrect = false;
                break;
            }
            else
            {
                compositionCorrect = true;
                Debug.Log("Every color reached goal");
            }
        }

        if(compositionCorrect)
        {
            FrameFillMachine.ShowSuccessMessage();
            CompositionCorrectEvent.Invoke(); //Activates lever
        }

    }

    public void SubscribeFluidAmountChanged(Action<float> method)
    {
        FluidAmountChanged += method;
    }

    public void SubscribeCompositionCorrectEvent(Action method)
    {
        CompositionCorrectEvent += method;
    }
}
