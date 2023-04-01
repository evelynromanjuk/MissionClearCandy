using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour, IInteractable
{
    public KeypadManager KeypadManager;

    private Pipe _pipe;
    private bool _isInteractable;

    // Start is called before the first frame update
    void Start()
    {
        Pipe parentPipe = transform.parent.gameObject.GetComponent<Pipe>();
        if(parentPipe)
        {
            _pipe = parentPipe;
        }

        _isInteractable = false;
        KeypadManager.SubscribeCorrectRecipeEntered(ChangeInteractableStatus);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
