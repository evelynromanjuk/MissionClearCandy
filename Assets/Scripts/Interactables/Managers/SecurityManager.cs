using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityManager : MonoBehaviour
{
    //public SecurityElement CandyMachine;
    //public SecurityElement Analyzer;
    //public SecurityElement Door1;
    public SecurityElement Door2;

    public Lever Lever;
    public SecurityElementDisplay SecurityElementDisplay;

    // Start is called before the first frame update
    //void Start()
    //{
    //    KeypadManager.SubscribeCorrectPasswordEntered(ActivateDoor2);
    //}

    public void Initizalize(bool isRobotScene)
    {
        if(!isRobotScene)
        {
            Lever.SubscribeSubstanceEjected(ActivateDoor2);
        }
    }

   void ActivateDoor2()
    {
        Door2.SetActive(true);
        SecurityElementDisplay.ShowDetails();
        SecurityElementDisplay.ActivateLockButton();
    }
}
