using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMScreenManager : MonoBehaviour
{
    public Scanner Scanner;
    public CMScreen CMScreen;

    // Start is called before the first frame update
    void Start()
    {
        Scanner.Subscribe(OnScan);
    }

   void OnScan(EmployeeCard card)
    {
        string employeeName = card.GetEmployeeName();
        string employeePassword = card.GetPassword();
        CMScreen.OpenSignInFrame(employeeName, employeePassword);
    }
}
