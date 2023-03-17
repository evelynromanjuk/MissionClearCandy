using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    private List<TubeLight> _tubeLights = new List<TubeLight>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddTubeLight(TubeLight TubeLight)
    {
        _tubeLights.Add(TubeLight);
    }

    public void TurnOffOtherLights(TubeLight Caller)
    {
        foreach (TubeLight Entry in _tubeLights)
        {
            if (Entry != Caller)
            {
                Entry.TurnOff();
            }
        }
    }
}
