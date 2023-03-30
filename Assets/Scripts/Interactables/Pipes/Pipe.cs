using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour, IInteractable
{
    public Fluid Fluid;
    public FluidCompositionManager FluidCompositionManager;


    private void Awake()
    {
        FluidCompositionManager.AddFluidToList(Fluid);
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = Fluid.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log("Interacted with Pipe");
    }
}
