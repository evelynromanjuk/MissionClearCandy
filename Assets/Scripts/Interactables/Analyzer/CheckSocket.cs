using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class CheckSocket : MonoBehaviour
{
    public GameObject AnalyzerPart;
    private XRSocketInteractor _socket;

    Action<int, bool> PartInsertedEvent;

    // Start is called before the first frame update
    void Start()
    {
        _socket = GetComponent<XRSocketInteractor>();
    }

    public void SubscribePartInsertedEvent(Action<int, bool> method)
    {
        PartInsertedEvent += method;
    }

    public void CheckPart(int socketID)
    {
        bool partIsCorrect = false;

        IXRSelectInteractable insertedPart = _socket.GetOldestInteractableSelected();

        if (insertedPart == null)
        {
            Debug.Log("Inserted Object is Null");
        }
        if (AnalyzerPart == null)
        {
            Debug.Log("Reference Object is Null");
        }

        if (AnalyzerPart.transform.name == insertedPart.transform.name)
        {
            partIsCorrect = true;
            Debug.Log("Correct part.");
        }
        else
        {
            Debug.Log("Incorrect part.");
        }

        PartInsertedEvent.Invoke(socketID, partIsCorrect);
    }
}
