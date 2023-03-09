using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private RobotHUD robotHUD;
    private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        robotHUD = GetComponent<RobotHUD>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        robotHUD.UpdateScannedObjectName(string.Empty);

        //create a ray at the center of the camera, shooting outwards
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; //variable to store collision information
        if (Physics.Raycast(ray, out hitInfo, distance, mask)) //aussortieren was nicht den layer hat
        {
            //if (hitInfo.collider.GetComponent<Interactable>() != null) //check if hit gameObject has interactable component
            //{
            //    Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
            //    //robotHUD.UpdateScannedObjectName(interactable.promptMessage);
            //    robotHUD.UpdateScannedObjectName(interactable.name);
            //    if (inputManager.onFoot.Interact.triggered)
            //    {
            //        interactable.BaseInteract();
            //    }
            //}
            if (hitInfo.collider.GetComponent<ScannableObject>() != null) //check if hit gameObject has interactable component
            {
                ScannableObject scannableObject = hitInfo.collider.GetComponent<ScannableObject>();
                //robotHUD.UpdateScannedObjectName(interactable.promptMessage);
                robotHUD.UpdateScannedObjectName(scannableObject.name);
                if (inputManager.onFoot.Interact.triggered)
                {
                    scannableObject.Interact();
                }
            }
        }
    }
}
