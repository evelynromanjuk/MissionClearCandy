using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseFurniture : MonoBehaviour
{
    //[SerializeField] private Animator _interactableObject = null;
    private Animator _interactableObject;

    [SerializeField]
    private Animator _backupAnimator;

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

        _interactableObject = GetComponent<Animator>();
        if(_interactableObject == null)
        {
            _interactableObject = _backupAnimator;
        }
    }

    public void SetActive()
    {
        Debug.Log("Interacted with furniture");
        if (!isOpen)
        {
            if (_interactableObject == null)
            {
                Debug.Log("_interactableObject is null");
            }

            _interactableObject.Play("Open", 0, 0.0f);
            AudioManager.Instance.Play(OpeningSoundName);
            isOpen = true;
        }
        else
        {
            if(_interactableObject == null)
            {
                Debug.Log("_interactableObject is null");
            }
            _interactableObject.Play("Close", 0, 0.0f);
            AudioManager.Instance.Play(ClosingSoundName);
            isOpen = false;
        }
    }
}
