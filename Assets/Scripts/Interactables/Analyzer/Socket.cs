using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class Socket : MonoBehaviour
{
    public GameObject MachinePartReference; //the correct, intended machine part for this socket, used for comparison
    public AnalyzerManager AnalyzerManager;

    private XRSocketInteractor _socket;
    private IXRSelectInteractable insertedPart;


    void Start()
    {
        _socket = GetComponent<XRSocketInteractor>();
        AnalyzerManager.AddToSocketList(this);
    }

    public bool CheckPart()
    {
        bool partIsCorrect = false;

        insertedPart = _socket.GetOldestInteractableSelected();

        if (MachinePartReference == null)
        {
            Debug.Log("Reference Object is Null");
        }
        if (insertedPart == null)
        {
            Debug.Log("Inserted Object is Null");
        }

        if ((insertedPart != null) && (MachinePartReference.transform.name == insertedPart.transform.name))
        {
            partIsCorrect = true;
        }
        MachinePartReference.GetComponent<MachinePart>().UpdateMachinePart(partIsCorrect);

        return partIsCorrect;
    }
}
