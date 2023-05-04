using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public PlayerInteract PlayerInteract;
    public Animator _doorAnimator = null;

    private bool _isActive = false;
    private bool _isOpen = false;

    private void Start()
    {
        PlayerInteract.SubscribeDoorActivated(ActivateDoor);
    }

    public void OpenDoor()
    {
        if(_isActive)
        {
            Debug.Log("OpenDoor");

            if(!_isOpen)
            {
                _doorAnimator.Play("Open", 0, 0.0f);
                _isOpen = true;
            }
            else
            {
                Debug.Log("Door is already open.");
            }
        }
        else
        {
            Debug.Log("Door cannot be opened.");
            
        }
    }

    public void ActivateDoor(bool isActivated)
    {
        _isActive = isActivated;
        Debug.Log("Is it activated? : " + _isActive + ", " + isActivated);
    }
}
