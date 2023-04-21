using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Lever : MonoBehaviour, IInteractable
{
    public FluidCompositionManager FluidCompositionManager;
    public SpawnBall SpawnBall;

    private XRSimpleInteractable simpleInteractable = null;

    private void Awake()
    {
        simpleInteractable = gameObject.GetComponent<XRSimpleInteractable>();
        simpleInteractable.enabled = true;
    }
    // Start is called before the first frame update
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
    }

    public void Interact()
    {
        SpawnBall.Spawn();
    }
}
