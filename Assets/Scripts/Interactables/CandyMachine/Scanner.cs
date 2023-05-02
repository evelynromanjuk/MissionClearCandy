using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scanner : MonoBehaviour
{
    static Action<EmployeeCard> CardScanned;
    static Action CardRemoved;

    //private bool _isSubscribed = false;
    //private int _countbefore;
    //private static int _subscribercount;


    //private void Awake()
    //{
    //    _subscribercount = 0;
    //}

    //EVENT SUBSCRIPTIONS
    public void SubscribeCardScanned(Action<EmployeeCard> method)
    {
        CardScanned += method;
        //_isSubscribed = true;

        int count = 0;
        foreach(Delegate d in CardScanned.GetInvocationList())
        {
            count++;
        }
        //_subscribercount = count;

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

        //Debug.Log("Collision with Employee Card detected");
        //Debug.Log("Employee Name: " + card.GetEmployeeName());
        //Debug.Log("Employee Password: " + card.GetPassword());
        //Debug.Log("Is valid: " + card.GetCardValidity());

        if (card.GetCardValidity())
        {
            CardScanned?.Invoke(card);
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        CardRemoved?.Invoke();
        // TODO: Change Screen text back to "Please put ID card on the scanner"
    }

    private void OnApplicationQuit()
    {
        Debug.Log(this.gameObject.name);
       // _subscribercount = 0;
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        //Debug.Log("The last subscriberCount: " + _subscribercount);
    }

}
