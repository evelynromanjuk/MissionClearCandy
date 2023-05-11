using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public PlayerInteract PlayerInteract;
    public Animator _doorAnimator = null;
    public Lever Lever;

    private bool _substanceCreated = false;
    private bool _isActivatable;
    private bool _isOpenable;

    private bool _isActive = false;
    private bool _isOpen = false;
    private bool _isRobotScene;

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
    }

    private void SetDoorInteractable()
    {
        _substanceCreated = true;
    }

    public void OpenDoor()
    {
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

    public void ActivateDoor(bool isActivated)
    {
        _isActive = isActivated;
        Debug.Log("Is it activated? : " + _isActive + ", " + isActivated);
    }

    public void OpenDoorHacker()
    {
        if(_substanceCreated)
        {
            _doorAnimator.Play("Open", 0, 0.0f);
            _isOpen = true;
        }
    }
}
