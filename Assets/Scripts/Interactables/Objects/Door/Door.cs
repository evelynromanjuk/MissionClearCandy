using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public PlayerInteract PlayerInteract;
    public Animator _doorAnimator = null;

    private bool _isActivatable;
    private bool _isOpenable;

    private bool _isActive = false;
    private bool _isOpen = false;
    private bool _isRobotScene;

    private void Start()
    {
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

    public void OpenDoor()
    {
        if(_isOpenable)
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
}
