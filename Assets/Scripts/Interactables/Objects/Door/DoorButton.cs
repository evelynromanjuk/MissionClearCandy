using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Material LightRed ;
    public Material LightGreen;

    private MeshRenderer _renderer;
    private Material _currentMaterial;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _currentMaterial = _renderer.material;
    }


    public void SetButtonRed()
    {
        _renderer.material = LightRed;
    }
}
