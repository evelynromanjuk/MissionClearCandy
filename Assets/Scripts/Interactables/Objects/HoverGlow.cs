using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverGlow : MonoBehaviour
{
    Renderer rend;
    public Material GlowMaterial;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void ShowGlow()
    {
        Material[] matArray = rend.materials;
        int lastPosition = matArray.Length-1;
        Debug.Log("Last Position in Array: " + lastPosition);
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
}
