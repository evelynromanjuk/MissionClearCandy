using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseFurniture : MonoBehaviour
{
    [SerializeField] private Animator _interactableObject = null;

    public bool isOpen = false;


    public void SetActive()
    {
        if (!isOpen)
        {
            _interactableObject.Play("Open", 0, 0.0f);
            isOpen = true;
        }
        else
        {
            _interactableObject.Play("Close", 0, 0.0f);
            isOpen = false;
        }
    }
}
