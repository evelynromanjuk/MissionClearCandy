using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLever : MonoBehaviour, IInteractable
{
    //public PlayerInteract Player;
    public TubeLight TubeLight;
    public LightManager LightManager;


    public void Start()
    {
        LightManager.AddTubeLight(TubeLight);

    }
    public void Interact()
    {
        TubeLight.LightSwitching();
        LightManager.TurnOffOtherLights(TubeLight);

        Debug.Log("Lights, something happened");
    }
}
