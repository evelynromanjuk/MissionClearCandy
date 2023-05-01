using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scanner : MonoBehaviour
{
    Action<EmployeeCard> CardScanned;
    Action CardRemoved;

    private bool _isSubscribed = false;
    private int _countbefore;
    private int _subscribercount;


    private void Awake()
    {
        _subscribercount = 0;
    }

    //EVENT SUBSCRIPTIONS
    public void SubscribeCardScanned(Action<EmployeeCard> method)
    {
        CardScanned += method;
        _isSubscribed = true;

        int count = 0;
        foreach(Delegate d in CardScanned.GetInvocationList())
        {
            count++;
        }
        _subscribercount = count;

        Debug.Log("Someone subscribed?" + _isSubscribed);
        Debug.Log("Subscriber Count: " + _subscribercount);
    }

    public void SubscribeCardRemoved(Action method)
    {
        CardRemoved += method;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("000CardScanned is null? " + (CardScanned == null));
        EmployeeCard card = collision.gameObject.GetComponent<EmployeeCard>();
        if(card == null)
        {
            Debug.Log("the card is null? " + (card == null));
            return;
        }

        //Debug.Log("Collision with Employee Card detected");
        //Debug.Log("Employee Name: " + card.GetEmployeeName());
        //Debug.Log("Employee Password: " + card.GetPassword());
        //Debug.Log("Is valid: " + card.GetCardValidity());

        _subscribercount = 1;
        Debug.Log("CardScanned is null? " + (CardScanned==null));
        Debug.Log("Subscriber Count2: " + _subscribercount);
        Debug.Log("Someone subscribed?" + _isSubscribed);

        if (card.GetCardValidity())
        {
            Debug.Log("Number of methods subscribed to CardScanned: " + CardScanned.GetInvocationList());
            CardScanned?.Invoke(card);
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("No longer in contact with " + collision.transform.name);
        CardRemoved.Invoke();
        // TODO: Change Screen text back to "Please put ID card on the scanner"
    }

    private void OnApplicationQuit()
    {
        Debug.Log(this.gameObject.name);
        _subscribercount = 0;
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("The last subscriberCount: " + _subscribercount);
    }

}
