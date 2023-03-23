using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{

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
    }

}
