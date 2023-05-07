using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityManager : MonoBehaviour
{
    public SecurityElement CandyMachine;
    public SecurityElement Analyzer;
    public SecurityElement Door1;
    public SecurityElement Door2;

    public KeypadManager KeypadManager;
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
            KeypadManager.SubscribeCorrectPasswordEntered(ActivateDoor2);
        }
    }

   void ActivateDoor2(bool IsCorrect)
    {
        if(IsCorrect)
        {
            Door2.SetActive(true);
            SecurityElementDisplay.ShowDetails();
        }
    }
}
