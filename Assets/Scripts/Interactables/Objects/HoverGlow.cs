using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class HoverGlow : MonoBehaviour
{
    Renderer rend;
    public Material GlowMaterial;
    private XRBaseInteractable _interactable;

    void Awake()
    {
        rend = GetComponent<Renderer>();

        _interactable = GetComponent<XRBaseInteractable>();

        UnityAction<HoverEnterEventArgs> hoverEnterAction = new UnityAction<HoverEnterEventArgs>(OnHoverEntered);
        _interactable.hoverEntered.AddListener(hoverEnterAction);

        UnityAction<HoverExitEventArgs> hoverExitedAction = new UnityAction<HoverExitEventArgs>(OnHoverExited);
        _interactable.hoverExited.AddListener(hoverExitedAction);
    }

    public void ShowGlow()
    {
        Material[] matArray = rend.materials;
        int lastPosition = matArray.Length-1;
        matArray[lastPosition] = GlowMaterial;
        rend.materials = matArray;
    }

    public void HideGlow()
    {
        Material[] matArray = rend.materials;
        int lastPosition = matArray.Length - 1;
        matArray[lastPosition] = null;
        rend.materials = matArray;
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        Material[] matArray = rend.materials;
        int lastPosition = matArray.Length - 1;
        Debug.Log("Last Position in Array: " + lastPosition);
        matArray[lastPosition] = GlowMaterial;
        rend.materials = matArray;
    }

    private void OnHoverExited(HoverExitEventArgs args)
    {
        Material[] matArray = rend.materials;
        int lastPosition = matArray.Length - 1;
        matArray[lastPosition] = null;
        rend.materials = matArray;
    }
}
