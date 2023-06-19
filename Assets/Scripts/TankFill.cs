using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TankFill : MonoBehaviour
{
    public FluidCompositionManager FluidCompositionManager;
    public TMP_Text CurrentPercentageText;

    private Material _tankMaterial;
    private Image _cmFill;
    

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if(renderer != null)
        {
            _tankMaterial = GetComponent<MeshRenderer>().material;
        }
        
        _cmFill = GetComponent<Image>();
        //CurrentPercentage = GetComponent<TMP_Text>();

        FluidCompositionManager.SubscribeTankFillChanged(OnFluidAmountChanged);
        Debug.Log("TankFill subscribed to FluidCompositionManager");
    }
    
    void OnFluidAmountChanged(float tankFill)
    {
        //for UI
        float conversion = tankFill / 100;

        //for 3D
        float conversion2 = tankFill / 50;
        float tankFillRate = -1.1f + conversion2;

        if((_cmFill != null) & (CurrentPercentageText != null))
        {
            _cmFill.fillAmount = conversion;
            CurrentPercentageText.text = tankFill + "%";
        }
        else if(_tankMaterial != null)
        {
            _tankMaterial.SetFloat("_Fill", tankFillRate);
        }
        else
        {
            Debug.Log("TankFill: " + this.gameObject +". Both 3D and 2D tank visualisations are null. Nothing to update.");
        }
    }
}
