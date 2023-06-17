using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EjectButton : MonoBehaviour
{
    public FluidCompositionManager FluidCompositionManager;

    public bool _isInteractable;

    // Start is called before the first frame update
    void Start()
    {
        FluidCompositionManager.SubscribeCompositionCorrectEvent(OnSubstanceEjected);
    }

    // Update is called once per frame
    void OnSubstanceEjected()
    {
        if(_isInteractable)
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }
        
    }
}
