using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInteract : MonoBehaviour
{
    private Camera _cam;
    [SerializeField]
    private float _distance = 3f;
    [SerializeField]
    private LayerMask _mask;
    private RobotHUD _robotHUD;
    private InputManager _inputManager;

    private string[,] _scanData;

    Action<string[,]> ObjectScannedEvent;

    // Start is called before the first frame update
    void Start()
    {
        _cam = GetComponent<PlayerLook>().cam;
        _robotHUD = GetComponent<RobotHUD>();
        _inputManager = GetComponent<InputManager>();
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
            if (hitInfo.collider.GetComponent<ScannableObject>() != null) //check if hit gameObject has ScannableObject component
            {
                ScannableObject scannableObject = hitInfo.collider.GetComponent<ScannableObject>();
                _robotHUD.UpdateScannedObjectName(scannableObject.name);
                if (_inputManager.onFoot.Interact.triggered) //if clicked or E key pressed
                {
                    if (scannableObject.Scan() != null) //if scan data exists, invoke event and send data
                    {
                        _scanData = scannableObject.Scan();
                        ObjectScannedEvent.Invoke(_scanData);
                    }
                }
            }
        }
    }

    public void Subscribe(Action<string[,]> method)
    {
        ObjectScannedEvent += method;
    }
}
