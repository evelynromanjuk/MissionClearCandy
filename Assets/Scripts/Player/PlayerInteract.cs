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
    Action<string, bool> PipeActivated;
    Action<bool> DoorActivated;
    Action<bool> AnalyzerActivated;
    Action<bool> EnvironmentScanned;

    private ScannableObject _currentScannableObj;
    private IInteractable _currentInteractableObj;
    private TMP_InputField _currentInputField;

    private bool _doorButtonFocused = false;
    private bool _analyzerFocused = false;
    private bool _isVersionD = false;


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
        _inputManager.onFoot.ActivatePipe.started += OnActivatePipe;
        _inputManager.onFoot.ActivatePipe.canceled += OnDeactivatePipe;
        _inputManager.onFoot.HoldInteract.started += OnActivateDoor;
        _inputManager.onFoot.HoldInteract.canceled += OnDeactivateDoor;
        _inputManager.onFoot.EnvironmentScan.started += OnScanEnvironmentStart;
        _inputManager.onFoot.EnvironmentScan.canceled += OnScanEnvironmentStop;
    }

    public void Initialize(bool isVersionD)
    {
        _isVersionD = isVersionD;
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
            //_currentInputField.interactable = true; //could be added later if "interactable" should be set automatically with raycast

            DoorButton DoorButton = hitInfo.collider.GetComponent<DoorButton>();
            if (DoorButton != null & !_doorButtonFocused)
            {
                _doorButtonFocused = true;
                _inputManager.SwitchInteract(true);
            }

            AnalyzerConnection AnalyzerConnection = hitInfo.collider.GetComponent<AnalyzerConnection>();
            if (AnalyzerConnection != null & !_doorButtonFocused)
            {
                _analyzerFocused = true;
                _inputManager.SwitchInteract(true);
            }


        }
        else
        {
            if(_currentScannableObj != null)
            {
                _currentScannableObj = null;
            }
            if (_currentInputField != null)
            {
                _currentInputField.interactable = false;
                _currentInputField = null;
            }

            if (_doorButtonFocused)
            {
                _doorButtonFocused = false;
                _inputManager.SwitchInteract(false);
            }

            if (_analyzerFocused)
            {
                _analyzerFocused = false;
                _inputManager.SwitchInteract(false);
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

        Debug.Log("INTERACT");
    }

    //EVENT: ESC pressed
    private void OnReturnPressed(InputAction.CallbackContext Callback)
    {
        OnReturn.Invoke();
    }

    //EVENT: keyboard key pressed, handles depending on key
    private void OnKeyboardEnter(InputAction.CallbackContext obj)
    {
        if(_isVersionD)
        {
            if (_currentInputField != null && _currentInputField.interactable == true)
            {
                string keyValue = obj.control.name;

                if (keyValue.Equals("enter"))
                {
                    _currentInputField.interactable = false;
                    PasswordEntered.Invoke(_currentInputField.text);
                }
                else if (keyValue.Equals("backspace"))
                {
                    _currentInputField.text = _currentInputField.text.Remove(_currentInputField.text.Length - 1);
                }
                else
                {
                    _currentInputField.text += keyValue;
                }
                //Debug.Log("Pressed: " + keyValue);
            }
        }
      
    }

    private void OnActivatePipe(InputAction.CallbackContext obj)
    {
        if(_isVersionD)
        {
            string keyValue = obj.control.name;

            if(keyValue.Equals("z"))
            {
                keyValue = "y";
            }

            PipeActivated.Invoke(keyValue, true);
            Debug.Log("Hacker pressed Key: " + keyValue);
        }
       
    }

    private void OnDeactivatePipe(InputAction.CallbackContext obj)
    {
        if(_isVersionD)
        {
            string keyValue = obj.control.name;

            if (keyValue.Equals("z"))
            {
                keyValue = "y";
            }

            //PipeActivated(keyValue, false);
            PipeActivated.Invoke(keyValue, false);
            Debug.Log("Hacker released Key: " + keyValue);
        }
        
    }

    private void OnActivateDoor(InputAction.CallbackContext obj)
    {
        if(_doorButtonFocused)
        {
            DoorActivated.Invoke(true);
            Debug.Log("Door was activated");
        }
        if(_analyzerFocused)
        {
            AnalyzerActivated.Invoke(true);
            Debug.Log("Analyzer was activated");
        }

    }

    private void OnDeactivateDoor(InputAction.CallbackContext obj)
    {
        if(_doorButtonFocused)
        {
            DoorActivated.Invoke(false);
            Debug.Log("Door was deactivated");
        }
        if(_analyzerFocused)
        {
            AnalyzerActivated.Invoke(false);
            Debug.Log("Analyzer was deactivated");
        }

    }

    private void OnScanEnvironmentStart(InputAction.CallbackContext obj)
    {
        Debug.Log("Scan Environment Start");
        EnvironmentScanned.Invoke(true);
    }

    private void OnScanEnvironmentStop(InputAction.CallbackContext obj)
    {
        Debug.Log("Scan Environment Stop");
        EnvironmentScanned.Invoke(false);
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

    public void SubscribePipeActivated(Action<string, bool> method)
    {
        PipeActivated += method;
    }

    public void SubscribeDoorActivated(Action<bool> method)
    {
        DoorActivated += method;
    }

    public void SubscribeAnalyzerActivated(Action<bool> method)
    {
        AnalyzerActivated += method;
    }

    public void SubscribeEnvironmentScanned(Action<bool> method)
    {
        EnvironmentScanned += method;
    }
}
