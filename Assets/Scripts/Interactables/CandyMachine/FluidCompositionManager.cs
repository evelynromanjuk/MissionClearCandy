using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidCompositionManager : MonoBehaviour
{
    //public FrameFillMachine FrameFillMachine;

    private static List<Fluid> _fluids = new List<Fluid>();
    //Action<float> FluidAmountChanged;
    Action<Fluid> FluidAmountChanged;
    static Action<List<Fluid>> FluidListReady;
    Action CompositionCorrectEvent;

    private float totalPercentage = 0;

    void Start()
    {
        FluidListReady.Invoke(_fluids);
    }

    public void AddFluidToList(Fluid fluid)
    {
        _fluids.Add(fluid);
    }

    public bool AddFluid(Fluid fluid, float percentage)
    {
        bool tankIsFull = false;
        string agentKey = fluid.Key;

        // TODO: Change back to 100%
        if ((totalPercentage + percentage) <= 35) //if tank will not be 100% full
        {
            fluid.CurrentPercentage += percentage;
            totalPercentage += percentage;
            //FrameFillMachine.UpdateFluidData(fluid);
            FluidAmountChanged.Invoke(fluid);

            if (fluid.CurrentPercentage == fluid.GoalPercentage)
            {
                Debug.Log("Percentage goal reached.");
                fluid.ReachedGoal = true;
                CheckComposition();
            }
            if (fluid.CurrentPercentage > fluid.GoalPercentage)
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
            }
        }

        if(compositionCorrect)
        {
            //FrameFillMachine.ShowSuccessMessage();
            CompositionCorrectEvent.Invoke(); //Activates lever
        }

    }

    public void SubscribeFluidListReady(Action<List<Fluid>> method)
    {
        FluidListReady += method;
    }

    public void SubscribeFluidAmountChanged(Action<Fluid> method)
    {
        FluidAmountChanged += method;
    }

    public void SubscribeCompositionCorrectEvent(Action method)
    {
        CompositionCorrectEvent += method;
    }
}
