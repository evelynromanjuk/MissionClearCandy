using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeLight : MonoBehaviour
{
    private bool isOn;

    public void Start()
    {
        isOn = false;
        this.gameObject.SetActive(isOn);
    }
    public void LightSwitching()
    {
       if(isOn)
        {
            isOn = false;
        }
       else
        {
            isOn = true;
        }
        this.gameObject.SetActive(isOn);
    }

    public void TurnOff()
    {
        isOn = false;
        this.gameObject.SetActive(isOn);
    }

}
