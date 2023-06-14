using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TankControl : MonoBehaviour
{
    public FrameFillMachine FrameFillMachine2D;
    public TMP_Text DefaultText;
    public KeypadManager KeypadManager;

    private bool _codeIsExternal;

    void Start()
    {
        //code is "external" if hacker enters it
        //if agent enters the recipe code, tank control subscribes to the KeypadManager
        if(!_codeIsExternal)
        {
            KeypadManager.SubscribeCorrectRecipeEntered(ShowFluidList);
        }
        
    }

    public void Initialize(bool isVersionB)
    {
        _codeIsExternal = isVersionB;
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
