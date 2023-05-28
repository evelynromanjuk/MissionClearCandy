using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class CheckSocket : MonoBehaviour
{
    public GameObject MachinePartReference; //the correct, intended machine part for this socket, used for comparison
    private XRSocketInteractor _socket;
    public AnalyzerManager AnalyzerManager;


    void Start()
    {
        _socket = GetComponent<XRSocketInteractor>();
    }

    public void CheckPart(int socketID)
    {
        bool partIsCorrect = false;

        IXRSelectInteractable insertedPart = _socket.GetOldestInteractableSelected();

        //if (insertedPart == null)
        //{
        //    Debug.Log("Inserted Object is Null");
        //}
        //if (MachinePartReference == null)
        //{
        //    Debug.Log("Reference Object is Null");
        //}

        if (MachinePartReference.transform.name == insertedPart.transform.name)
        {
            partIsCorrect = true;
            Debug.Log("Correct part.");
        }
        else
        {
            Debug.Log("Incorrect part.");
        }

        MachinePartReference.GetComponent<MachinePart>().UpdateMachinePart(partIsCorrect);
        AnalyzerManager.CheckAllSockets();
    }
}
