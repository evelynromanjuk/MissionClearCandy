using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CodeLockManager : MonoBehaviour
{
    public CodeLock Lock1;
    public CodeLock Lock2;
    public CodeLock Lock3;
    public CodeLock Lock4;
    public XRGrabInteractable LockerDoor;

    private List<CodeLock> _codeLocks = new List<CodeLock>();
    private bool _allCorrect;

    // Start is called before the first frame update
    void Start()
    {
        _codeLocks.Add(Lock1);
        _codeLocks.Add(Lock2);
        _codeLocks.Add(Lock3);
        _codeLocks.Add(Lock4);

        _allCorrect = false;
    }
    
    public void CheckLocks()
    {
        foreach(var entry in _codeLocks)
        {
            _allCorrect = (entry.IsCorrect()) ? true : false;
        }

        if(_allCorrect)
        {
            LockerDoor.enabled = true;
            Debug.Log("all correct");
        }
    }
}
