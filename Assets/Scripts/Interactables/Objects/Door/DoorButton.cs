using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{ 
    public Material LightRed;
    public Material LightGreen;
    public Door Door;

    private MeshRenderer _renderer;
    private Material _currentMaterial;

    private void Start()
    { 
        if(Door != null)
        {
            Door.SubscribeDoorActiveEvent(SetButtonGreen);
            _renderer = GetComponent<MeshRenderer>();
            _currentMaterial = _renderer.material;
        }
        
    }


    public void SetButtonRed()
    {
        _renderer.material = LightRed;
    }

    public void SetButtonGreen(bool isActive)
    {
        if (isActive)
        {
            _renderer.material = LightGreen;
        }
        else
        {
            SetButtonRed();
        }
    }
}
