using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit;

public class EmptyButton : MonoBehaviour, IInteractable
{
    public KeypadManager KeypadManager;
    public RecipeSearch RecipeSearch;

    Action<Fluid> MachineEmptied;

    private List<Fluid> _fluids = new List<Fluid>();
    private bool _isInteractable = false;
    private bool _codeIsExternal = false;

    private void Start()
    {
        KeypadManager.SubscribeCorrectRecipeEntered(EnableEmptyButton);
    }

    public void Initialize(bool isVersionB)
    {
        _codeIsExternal = isVersionB; //code is external meaning that the hacker is entering the recipe code, which is the case in Version B
        if (_codeIsExternal)
        {
            RecipeSearch.SubscribeCorrectCodeEntered(EnableEmptyButton);
        }
    }

    public void SubscribeMachineEmptied(Action<Fluid> method)
    {
        MachineEmptied += method;
    }

    public void Interact()
    {
        if(_isInteractable)
        {
            foreach (var entry in _fluids)
            {
                entry.CurrentPercentage = 0;
                MachineEmptied.Invoke(entry);
            }
        }
        else
        {
            Debug.Log("Empty Button disabled. Cannot interact");
        }
       
    }

    public void AddFluidToList(Fluid fluid) // TODO: remove later if not needed
    {
        _fluids.Add(fluid);
    }

    private void EnableEmptyButton(bool codeIsCorrect)
    {
        if(codeIsCorrect)
        {
            _isInteractable = true;

            Debug.Log("Empty Button enabled");
        }
    }

    private void EnableEmptyButton()
    {
        _isInteractable = true;
        Debug.Log("Empty Button enabled");
    }
}
