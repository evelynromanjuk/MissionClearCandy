using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : MonoBehaviour
{
    public PlayerInteract PlayerInteract;
    public Animator _doorAnimator = null;
    public Lever Lever;
    public DoorButton DoorButton;

    private bool _substanceCreated = false;
    private bool _isActivatable;
    private bool _isOpenable; //false for Version B, in regards to the agent

    private bool _isActive = false;
    private bool _isOpen = false;
    private bool _isRobotScene;

    Action<bool> DoorActiveEvent;

    private void Start()
    {
        Lever.SubscribeSubstanceEjected(SetDoorInteractable);
        if(_isRobotScene)
        {
            PlayerInteract.SubscribeDoorActivated(ActivateDoor);
        }
    }

    public void InitializeDoor(bool isRobotScene, bool isActivatable, bool isOpenable)
    {
        _isRobotScene = isRobotScene;
        _isActivatable = isActivatable;
        _isOpenable = isOpenable;

        Debug.Log("DOOR: IsRobotScene = " + _isRobotScene + ", IsActivatable = " + _isActivatable + ", IsOpenable = " + _isOpenable);
    }

    private void SetDoorInteractable() //called when lever pulled or eject button pressed
    {
        _substanceCreated = true;

        if(!_isActivatable & _isOpenable) //Version C
        {
            DoorButton.SetButtonGreen(true);
        }
        else
        {
            DoorButton.SetButtonRed();
        }
        
    }

    public void OpenDoor()
    {
        Debug.Log("Trying to open door");
        if(_isOpenable & _substanceCreated)
        {
            if (!_isActivatable || (_isActivatable & _isActive))
            {
                Debug.Log("OpenDoor");

                if (!_isOpen)
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
    }

    public void OpenDoorHacker() //only for Version B, entirely remotely
    {
        if(_substanceCreated)
        {
            if (!_isOpen)
            {
                _doorAnimator.Play("Open", 0, 0.0f);
                _isOpen = true;
                Debug.Log("Door was opened");
            }
            else
            {
                Debug.Log("Door is already open.");
            }
        }

    }

    public void ActivateDoor(bool isActivated)
    {
        _isActive = isActivated;
        Debug.Log("Is it activated? : " + _isActive + ", " + isActivated);

        if(_substanceCreated)
        {
            DoorActiveEvent.Invoke(_isActive);
        }
        
    }

    public void SubscribeDoorActiveEvent(Action<bool> method)
    {
        DoorActiveEvent += method;
    }

}
