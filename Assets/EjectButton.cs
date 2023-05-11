using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EjectButton : MonoBehaviour
{
    public FluidCompositionManager FluidCompositionManager;

    // Start is called before the first frame update
    void Start()
    {
        FluidCompositionManager.SubscribeCompositionCorrectEvent(OnSubstanceEjected);
    }

    // Update is called once per frame
    void OnSubstanceEjected()
    {
        this.gameObject.GetComponent<Button>().interactable = true;
    }
}
