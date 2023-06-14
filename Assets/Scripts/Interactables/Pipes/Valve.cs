using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour, IInteractable
{
    public KeypadManager KeypadManager;
    public RecipeSearch RecipeSearch;

    private Pipe _pipe;
    private bool _isInteractable;
    private static bool _codeIsExternal = false;

    // Start is called before the first frame update
    void Start()
    {
        Pipe parentPipe = transform.parent.gameObject.GetComponent<Pipe>();
        if(parentPipe)
        {
            _pipe = parentPipe;
        }

        _isInteractable = false;
        
        if(_codeIsExternal)
        {
            RecipeSearch.SubscribeCorrectCodeEntered(ChangeInteractableStatus);
        }
        else
        {
            KeypadManager.SubscribeCorrectRecipeEntered(ChangeInteractableStatus);
        }
    }

    public void Initialize(bool isVersionB)
    {
        _codeIsExternal = isVersionB;
    }

    public void Interact()
    {
        if(_isInteractable)
        {
            _pipe.OpenClosePipe();
        }
    }

    void ChangeInteractableStatus(bool codeIsCorrect)
    {
        if(codeIsCorrect)
        {
            _isInteractable = true;
        }
    }

    void ChangeInteractableStatus()
    {
        _isInteractable = true;
    }
}
