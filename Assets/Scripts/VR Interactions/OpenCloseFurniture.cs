using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseFurniture : MonoBehaviour
{
    [SerializeField] private Animator _interactableObject = null;

    public bool isOpen = false;
    public string OpeningSoundName;
    public string ClosingSoundName;

    private void Start()
    {
        if(OpeningSoundName == null)
        {
            Debug.Log("OpeningSoundName for " + this.gameObject + " not set.");
        }

        if (ClosingSoundName == null)
        {
            Debug.Log("ClosingSoundName for " + this.gameObject + " not set.");
        }
    }

    public void SetActive()
    {
        Debug.Log("Interacted with furniture");
        if (!isOpen)
        {
            _interactableObject.Play("Open", 0, 0.0f);
            AudioManager.Instance.Play(OpeningSoundName);
            isOpen = true;
        }
        else
        {
            _interactableObject.Play("Close", 0, 0.0f);
            AudioManager.Instance.Play(ClosingSoundName);
            isOpen = false;
        }
    }
}
