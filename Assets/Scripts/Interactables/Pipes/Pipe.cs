using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Fluid FluidData;
    public GameObject FluidObject;
    public FluidCompositionManager FluidCompositionManager;
    public EmptyButton EmptyButton;
    public PlayerInteract PlayerInteract;

    private bool _pipeOpen = false;
    private bool _pipeActive;
    private string _hackerKey;


    private void Awake()
    {
        FluidData.CurrentPercentage = 0;
        FluidData.ReachedGoal = false;
        FluidCompositionManager.AddFluidToList(FluidData);
        EmptyButton.AddFluidToList(FluidData);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerInteract.SubscribePipeActivated(ActivatePipe);
        FluidObject.GetComponent<Renderer>().material = FluidData.material;
    }

    private void ActivatePipe(string key, bool isActive)
    {
        if (!isActive)
        {
            _pipeActive = isActive;
            Debug.Log("Pipe is deactivated");
        }
        else
        {
            _pipeActive = isActive;
            _hackerKey = key;
            Debug.Log("Pipe is activated. Key: " + key);
        }
    }

    public void OpenClosePipe()
    {
        //if hacker presses right key -> pipe can be opened
        //if hacker releases
        if(_pipeActive)
        {
            if (_pipeOpen)
            {
                Debug.Log("Pipe was closed");
                ClosePipe();

            }
            else
            {
                if(_hackerKey.Equals(FluidData.Key))
                {
                    Debug.Log("Pipe was opened");
                    OpenPipe();
                }
                else
                {
                    Debug.Log("Hacker pressed the wrong key");
                }
                
            }
        }
        else
        {
            Debug.Log("Pipe couldn't be opened. Activate it first.");
        }

        //if (_pipeOpen)
        //{
        //    Debug.Log("Pipe was closed");
        //    ClosePipe();
            
        //}
        //else
        //{
        //    Debug.Log("Pipe was opened");
        //    OpenPipe();
        //}
    }

    void OpenPipe()
    {
        _pipeOpen = true;
        InvokeRepeating("IncreaseFluidAmount", 0.0f, 1);
    }

    void ClosePipe()
    {
        _pipeOpen = false;
        CancelInvoke("IncreaseFluidAmount");
    }

    void IncreaseFluidAmount()
    {
        bool tankIsFull = FluidCompositionManager.AddFluid(FluidData, 1);

        if(tankIsFull)
        {
            CancelInvoke("IncreaseFluidAmount");
        }
    }
}

