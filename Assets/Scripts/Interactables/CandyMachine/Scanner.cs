using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scanner : MonoBehaviour
{
    Action<EmployeeCard> ObjectScannedEvent;


    public void Subscribe(Action<EmployeeCard> method)
    {
        ObjectScannedEvent += method;
    }

    private void OnCollisionEnter(Collision collision)
    {
        EmployeeCard card = collision.gameObject.GetComponent<EmployeeCard>();
        if(card == null)
        {
            return;
        }
        
        Debug.Log("Collision with Employee Card detected");
        Debug.Log("Employee Name: " + card.GetEmployeeName());
        Debug.Log("Employee Password: " + card.GetPassword());
        Debug.Log("Is valid: " + card.GetCardValidity());

        ObjectScannedEvent.Invoke(card);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("No longer in contact with " + collision.transform.name);
        // TODO: Change Screen text back to "Please put ID card on the scanner"
    }

}
