using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class Lever : MonoBehaviour, IInteractable
{
    public FluidCompositionManager FluidCompositionManager;
    public SpawnBall SpawnBall;
    Action SubstanceEjected;

    private XRSimpleInteractable simpleInteractable;
    private bool _isInteractable = true; //is false in Version B, because only hacker can eject substance
    private bool _substanceCreated = false;

    private void Awake()
    {
        simpleInteractable = gameObject.GetComponent<XRSimpleInteractable>();
        simpleInteractable.enabled = false;
    }
    void Start()
    { 
        FluidCompositionManager.SubscribeCompositionCorrectEvent(OnCompositionCorrect);
    }

    public void DeactivateSimpleInteractable()
    {
        _isInteractable = false;
    }

    private void OnCompositionCorrect()
    {
        if(_isInteractable)
        {
            simpleInteractable.enabled = true;
        }
        _substanceCreated = true;
    }

    public void PullLever()
    {
        if(_substanceCreated)
        {
            //TO DO: play lever animation
            SpawnBall.Spawn();
            simpleInteractable.enabled = false;

            //Invoke event to activate door
            SubstanceEjected.Invoke();
        }
        else
        {
            Debug.Log("Lever cannot be pulled. Substance not created yet.");
        }
    }

    public void Interact()
    {
        if (simpleInteractable.enabled == true)
        {
            PullLever();
        }
    }

    public void SubscribeSubstanceEjected(Action method)
    {
        SubstanceEjected += method;
    }
}
