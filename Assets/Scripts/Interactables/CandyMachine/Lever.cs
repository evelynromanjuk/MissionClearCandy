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

    private void Awake()
    {
        simpleInteractable = gameObject.GetComponent<XRSimpleInteractable>();
        simpleInteractable.enabled = false;
    }
    void Start()
    { 
        FluidCompositionManager.SubscribeCompositionCorrectEvent(OnCompositionCorrect);
    }

    private void OnCompositionCorrect()
    {
        simpleInteractable.enabled = true;
    }

    public void PullLever()
    {
        //play lever animation
        SpawnBall.Spawn();
        simpleInteractable.enabled = false;

        //Invoke event to activate door
        SubstanceEjected.Invoke();

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
