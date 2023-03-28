using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private float _distance = 3f;
    [SerializeField] private LayerMask _mask;

    private RobotHUD _robotHUD;
    private InputManager _inputManager;

    private string[,] _scanData;

    Action<string[,]> ObjectScannedEvent;
    Action<bool> InfoFrameClosedEvent;
    Action OnReturn;
    Action<string> PasswordEntered;

    private ScannableObject _currentScannableObj;
    private IInteractable _currentInteractableObj;
    private TMP_InputField _currentInputField;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _cam = GetComponent<PlayerLook>().cam;
        _robotHUD = GetComponent<RobotHUD>();
        _inputManager = GetComponent<InputManager>();
        
        _inputManager.onFoot.Return.performed += OnReturnPressed;
        _inputManager.onFoot.Interact.performed += OnInteract;
        _inputManager.onFoot.KeyboardInput.performed += OnKeyboardEnter;
    }

    void Update()
    {
        _robotHUD.UpdateScannedObjectName(string.Empty);

        //create a ray at the center of the camera, shooting outwards
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * _distance);
        RaycastHit hitInfo; //variable to store collision information

        if (Physics.Raycast(ray, out hitInfo, _distance, _mask)) //to sort out what is not on scannable layer
        {
            string hitObjectName = hitInfo.collider.name;
            _robotHUD.UpdateScannedObjectName(hitObjectName);

            //SCANNABLE OBJECT
            ScannableObject scannableObject = hitInfo.collider.GetComponent<ScannableObject>();
            if (scannableObject != null) //check if hit gameObject has ScannableObject component
                _currentScannableObj = scannableObject;

            //INTERACTABLE OBJECT
            IInteractable interactableObject = hitInfo.collider.GetComponent<IInteractable>();
            _currentInteractableObj = interactableObject;

            //INPUT FIELD
            TMP_InputField InputField = hitInfo.collider.GetComponent<TMP_InputField>();
            _currentInputField = InputField;
        }
        else
        {
            if (_currentInputField != null)
            {
                _currentInputField.interactable = false;
                _currentInputField = null;
            }
        }
    }

    //handles interactions on button "E" pressed, depending on the object interacted with
    private void OnInteract(InputAction.CallbackContext obj)
    {
        if(_currentScannableObj)
        {
            if (_currentScannableObj.Scan() != null) //if scan data exists, invoke event and send data
            {
                _scanData = _currentScannableObj.Scan();
                ObjectScannedEvent.Invoke(_scanData);
            }
        }

        if(_currentInteractableObj != null)
        {
            _currentInteractableObj.Interact();
        }

        if(_currentInputField != null)
        {
            _currentInputField.interactable = true;
        }
    }

    //EVENT: ESC pressed
    private void OnReturnPressed(InputAction.CallbackContext Callback)
    {
        OnReturn.Invoke();
    }

    //EVENT: keyboard key pressed, handles depending on key
    private void OnKeyboardEnter(InputAction.CallbackContext obj)
    {
        if (_currentInputField != null && _currentInputField.interactable == true)
        {
            string keyValue = obj.control.name;
            
            if(keyValue.Equals("enter"))
            {
                Debug.Log("Your inserted password is: " + _currentInputField.text);
                _currentInputField.interactable = false;
                PasswordEntered.Invoke(_currentInputField.text);
            }
            else if(keyValue.Equals("backspace"))
            {
                _currentInputField.text = _currentInputField.text.Remove(_currentInputField.text.Length - 1);
            }
            else
            {
                _currentInputField.text += keyValue;
            }
        }
    }

    //EVENT SUBSCRIPTIONS
    public void SubscribeObjectScanned(Action<string[,]> method)
    {
        ObjectScannedEvent += method;
    }

    public void SubscribeInfoFrameClosed(Action<bool> method)
    {
        InfoFrameClosedEvent += method;
    }

    public void SubscribeReturn(Action method)
    {
        OnReturn += method;
    }

    public void SubscribePasswordEntered(Action<string> method)
    {
        PasswordEntered += method;
    }
}
