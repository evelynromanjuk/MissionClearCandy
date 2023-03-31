using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidCompositionManager : MonoBehaviour
{
    public FrameFillMachine FrameFillMachine;

    private List<Fluid> _fluids = new List<Fluid>();
    Action<float> FluidAmountChanged;

    private float totalPercentage = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Paste Fluid Data!!");
        FrameFillMachine.PasteFluidData(_fluids);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFluidToList(Fluid fluid)
    {
        _fluids.Add(fluid);
        Debug.Log("Added Fluid: " + fluid.FluidName);
    }

    public bool AddFluid(Fluid fluid, float percentage)
    {
        bool tankIsFull = false;

        if((totalPercentage + percentage) <= 100)
        {
            fluid.CurrentPercentage += percentage;
            totalPercentage += percentage;
            FrameFillMachine.UpdateFluidData(fluid);

            Debug.Log("FCM: Fluid percentage updated. Name: " + fluid.FluidName + ", " + fluid.CurrentPercentage + "%");

            if(fluid.CurrentPercentage == fluid.GoalPercentage)
            {
                Debug.Log("Percentage goal reached.");
                fluid.ReachedGoal = true;
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

    public void SubscribeFluidAmountChanged(Action<float> method)
    {
        FluidAmountChanged += method;
    }
}
