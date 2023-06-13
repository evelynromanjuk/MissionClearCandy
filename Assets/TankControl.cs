using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TankControl : MonoBehaviour
{
    public FrameFillMachine FrameFillMachine2D;
    public TMP_Text DefaultText;
    public KeypadManager KeypadManager;

    void Start()
    {
        KeypadManager.SubscribeCorrectRecipeEntered(ShowFluidList);
    }

    private void ShowFluidList(bool isCorrect)
    {
        if(isCorrect)
        {
            FrameFillMachine2D.gameObject.SetActive(true);
            DefaultText.gameObject.SetActive(false);
        }
    }
}
