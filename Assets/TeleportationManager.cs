using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class TeleportationManager : MonoBehaviour
{
    public GameObject BaseController;
    public GameObject TeleportationGameObject;

    public InputActionReference TeleportActivationReference;

    [Space]
    public UnityEvent onTeleportActivate;
    public UnityEvent onTeleportCancel;

    private void Start()
    {
        TeleportActivationReference.action.performed += TeleportModeActivate;
        TeleportActivationReference.action.canceled += TeleportModeCancel;
    }

    private void TeleportModeActivate(InputAction.CallbackContext obj) => onTeleportActivate.Invoke();

    private void TeleportModeCancel(InputAction.CallbackContext obj)
    {
        Invoke("DeactivateTeleporter", 0.1f);
    }

    void DeactivateTeleporter() => onTeleportCancel.Invoke();

}
