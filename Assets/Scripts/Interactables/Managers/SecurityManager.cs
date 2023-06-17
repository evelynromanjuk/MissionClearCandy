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
    public Door Door;
    public SecurityElementDisplay SecurityElementDisplay;

    private bool _doorExternallyOpened;

    public void Initizalize(bool isRobotScene, bool isVersionB)
    {
        if(!isRobotScene)
        {
            Lever.SubscribeSubstanceEjected(ActivateDoor2);
            if(isVersionB)
            {
                _doorExternallyOpened = isVersionB; //hacker opens the door via app
            }
        }
    }

   void ActivateDoor2()
    {
        Debug.Log("Security Manager: ACtivate Door");
        Door2.SetConnection(true);
        //Door.ActivateDoor(true);
        SecurityElementDisplay.ChangeKnobColor();
        SecurityElementDisplay.ActivateLockButton();
    }

    public void OpenDoor2()
    {
        Debug.Log("Security Manager: Open Door");
        Door2.SetLocked(false);
        Door.ActivateDoor(true);
        SecurityElementDisplay.ShowDetails();
        if(_doorExternallyOpened)
        {
            Door.OpenDoorHacker();
        }
        


    }
}
