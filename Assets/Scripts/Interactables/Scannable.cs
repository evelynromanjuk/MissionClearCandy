using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scannable : Interactable
{
    [SerializeField]
    private GameObject FramePrefab;

    private bool isInstantiated = false;

    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);

        if (!isInstantiated)
        {
            InstantiateScanInformationFrame();

        }
    }

    private void InstantiateScanInformationFrame()
    {
            GameObject parent = GameObject.Find("Canvas_RobotHUD");
            GameObject childPrefab = Instantiate(FramePrefab, parent.transform, false) as GameObject;
    }
}
