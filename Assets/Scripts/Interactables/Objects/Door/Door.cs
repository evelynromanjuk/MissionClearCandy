using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public PlayerInteract PlayerInteract;
    private static bool _isActive = false;

    private void Start()
    {
        PlayerInteract.SubscribeDoorActivated(ActivateDoor);
    }

    public void OpenDoor()
    {
        if(_isActive)
        {
            Debug.Log("OpenDoor");
        }
        else
        {
            Debug.Log("Nothing happened.");
        }
    }

    public void ActivateDoor(bool isActivated)
    {
        _isActive = isActivated;
        Debug.Log("Is it activated? : " + _isActive + ", " + isActivated);
    }
}
