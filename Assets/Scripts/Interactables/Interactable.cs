using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public float radius = 3f; //distance within which interactions are possible
    public string promptMessage;

    //this function will be called from our player
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        //no code written in this function
        //this is a template funciton to be overridden by our subclasses
    }
}
