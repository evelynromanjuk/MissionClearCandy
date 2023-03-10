using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public UIManager UIManager;

    private Camera _cam;
    [SerializeField] private float _distance = 3f;
    [SerializeField] private LayerMask _mask;

    private RobotHUD _robotHUD;
    private InputManager _inputManager;

    private string[,] _scanData;

    Action<string[,]> ObjectScannedEvent;
    Action<bool> InfoFrameClosedEvent;
    Action OnReturn;

    private ScannableObject _currentScannableObj;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _cam = GetComponent<PlayerLook>().cam;
        _robotHUD = GetComponent<RobotHUD>();
        _inputManager = GetComponent<InputManager>();
        
        _inputManager.onFoot.Return.performed += OnReturnPressed;
        _inputManager.onFoot.Interact.performed += OnInteract;
    }

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
    }

    private void OnReturnPressed(InputAction.CallbackContext Callback)
    {
        OnReturn.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        _robotHUD.UpdateScannedObjectName(string.Empty);

        //create a ray at the center of the camera, shooting outwards
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * _distance);
        RaycastHit hitInfo; //variable to store collision information

        if (Physics.Raycast(ray, out hitInfo, _distance, _mask)) //to sort out what is not on scannable layer
        {
            ScannableObject scannableObject = hitInfo.collider.GetComponent<ScannableObject>();
            if (scannableObject != null) //check if hit gameObject has ScannableObject component
            {
                _robotHUD.UpdateScannedObjectName(scannableObject.name);
            }
            _currentScannableObj = scannableObject;
        }
    }

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
}
