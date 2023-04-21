using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Lever : MonoBehaviour, IInteractable
{
    public FluidCompositionManager FluidCompositionManager;
    public SpawnBall SpawnBall;

    private XRSimpleInteractable simpleInteractable;

    private void Awake()
    {
        simpleInteractable = gameObject.GetComponent<XRSimpleInteractable>();
        simpleInteractable.enabled = false;

        Debug.Log("Awake method called");
    }
    // Start is called before the first frame update
    void Start()
    { 
        FluidCompositionManager.SubscribeCompositionCorrectEvent(OnCompositionCorrect);
    }

    private void OnCompositionCorrect()
    {
        Debug.Log("i think we got a problem");
        simpleInteractable.enabled = true;
    }

    public void PullLever()
    {
        //play lever animation
        SpawnBall.Spawn();
        simpleInteractable.enabled = false;
    }

    public void Interact()
    {
        if (simpleInteractable.enabled == true)
        {
            PullLever();
        }
    }
}
