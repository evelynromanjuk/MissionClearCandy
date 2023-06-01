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
        matArray[1] = GlowMaterial;
        rend.materials = matArray;
    }

    public void HideGlow()
    {
        Material[] matArray = rend.materials;
        matArray[1] = null;
        rend.materials = matArray;
    }
}
