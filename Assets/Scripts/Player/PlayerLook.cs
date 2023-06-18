using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    float xRotation = 0f;

    public float mouseSensitivity = 100f;

    private bool _isEnabled = true;

    public void ProcessLook(Vector2 input)
    {
        if(_isEnabled)
        {
            float mouseX = input.x;
            float mouseY = input.y;
            //calculate camera rotation for looking up and down
            xRotation -= (mouseY * Time.deltaTime) * mouseSensitivity;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);

            //apply to camera transform
            cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            //rotate player to look left and right
            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * mouseSensitivity);
        }
        
    }

    public void EnableLook(bool isEnabled)
    {
        _isEnabled = isEnabled;
    }
}
