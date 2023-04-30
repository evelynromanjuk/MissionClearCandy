using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scanner : MonoBehaviour
{
    Action<EmployeeCard> CardScanned;
    Action CardRemoved;

    //EVENT SUBSCRIPTIONS
    public void SubscribeCardScanned(Action<EmployeeCard> method)
    {
        CardScanned += method;
    }

    public void SubscribeCardRemoved(Action method)
    {
        CardRemoved += method;
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

        if(card.GetCardValidity())
        {
            CardScanned.Invoke(card);
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("No longer in contact with " + collision.transform.name);
        CardRemoved.Invoke();
        // TODO: Change Screen text back to "Please put ID card on the scanner"
    }

}
