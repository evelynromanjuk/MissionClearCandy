using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidCompositionManager : MonoBehaviour
{
    public EmptyButton EmptyButton;

    private static List<Fluid> _fluids = new List<Fluid>();

    Action<Fluid> FluidAmountChanged;
    Action<float> TankFillChanged;
    static Action<List<Fluid>> FluidListReady;
    Action CompositionCorrectEvent;
    Action GoalExceeded;

    private float totalPercentage = 0;

    void Start()
    {
        FluidListReady.Invoke(_fluids);
        EmptyButton.SubscribeMachineEmptied(ResetTotalPercentage);
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
            TankFillChanged.Invoke(totalPercentage);

            if (fluid.CurrentPercentage == fluid.GoalPercentage)
            {
                Debug.Log("Percentage goal reached.");
                fluid.ReachedGoal = true;
                CheckComposition();
            }
            if (fluid.CurrentPercentage > fluid.GoalPercentage)
            {
                fluid.ReachedGoal = false;
                GoalExceeded.Invoke();
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

    //every time the lever is pulled, a substance ball is created and the tank empties with each pull
    //returns bool if there is enough to create a ball
    public bool CheckSubstanceAmount()
    {
        bool enoughSubstance = false;
        int substancePerBall = 20;
        if((totalPercentage - substancePerBall) >= 0)
        {
            enoughSubstance = true;
            Debug.Log("A ball can be produced. Current percentage: " + totalPercentage);
            totalPercentage -= 20;
        }
        else
        {
            enoughSubstance = false;
            Debug.Log("There is not enough substance to produce a ball. Current percentage: " + totalPercentage);
        }
        return enoughSubstance;
    }

    private void ResetTotalPercentage(Fluid fluid)
    {
        totalPercentage = 0;
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

    public void SubscribeGoalExceeded(Action method)
    {
        GoalExceeded += method;
    }

    public void SubscribeTankFillChanged(Action<float> method)
    {
        TankFillChanged += method;
    }

    public void TestEvent()
    {
        totalPercentage = 100f;
        CompositionCorrectEvent.Invoke();
    }
}
