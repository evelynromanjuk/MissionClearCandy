using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Fluid FluidData;
    public GameObject FluidObject;
    public FluidCompositionManager FluidCompositionManager;

    private bool _isOpen = false;


    private void Awake()
    {
        FluidData.CurrentPercentage = 0;
        FluidData.ReachedGoal = false;
        FluidCompositionManager.AddFluidToList(FluidData);
    }

    // Start is called before the first frame update
    void Start()
    {
        FluidObject.GetComponent<Renderer>().material = FluidData.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenClosePipe()
    {
        if(_isOpen)
        {
            Debug.Log("Pipe was closed");
            ClosePipe();
            
        }
        else
        {
            Debug.Log("Pipe was opened");
            OpenPipe();
        }
    }

    void OpenPipe()
    {
        _isOpen = true;
        InvokeRepeating("IncreaseFluidAmount", 0.0f, 1);
    }

    void ClosePipe()
    {
        _isOpen = false;
        CancelInvoke("IncreaseFluidAmount");
    }

    void IncreaseFluidAmount()
    {
        FluidCompositionManager.AddFluid(FluidData, 1);
    }
}

