using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidCompositionManager : MonoBehaviour
{
    private List<Fluid> _fluids = new List<Fluid>();
    public FrameFillMachine FrameFillMachine;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Paste Fluid Data!!");
        FrameFillMachine.PasteFluidData(_fluids);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFluidToList(Fluid fluid)
    {
        _fluids.Add(fluid);
        Debug.Log("Added Fluid: " + fluid.FluidName);
    }
}
