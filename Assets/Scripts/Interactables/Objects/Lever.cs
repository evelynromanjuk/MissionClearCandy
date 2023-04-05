using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    public PlayerInteract Player;
    public TubeLight TubeLight;
    public LightManager LightManager;


    public void Start()
    {
        LightManager.AddTubeLight(TubeLight);

    }
    public void Interact()
    {
        //if(lightActive)
        //{
        //    lightActive = false;
        //}
        //else
        //{
        //    lightActive = true;
        //}
        TubeLight.LightSwitching();
        LightManager.TurnOffOtherLights(TubeLight);

    }

    


}
