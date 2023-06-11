using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnalyzerManager : MonoBehaviour
{
    public PlayerInteract PlayerInteract;
    // TODO: if not needed, remove machine part list
    //List<MachinePart> MachineParts = new List<MachinePart>();
    List<Socket> Sockets = new List<Socket>();

    static Action CheckedAllParts;
    Action SubstanceAnalyzedEvent;

    private bool _isRobotScene;
    private bool _substanceBallInserted;

    private bool _isActivatable = false;
    private bool _isActive = false;
    private bool _allCorrect;

    void Start()
    {
        _allCorrect = false;
        _substanceBallInserted = false;

        if(_isActivatable)
        {
            PlayerInteract.SubscribeAnalyzerActivated(ActivateAnalyzer);
        }
    }

    public void InitializeAnalyzer(bool isRobotScene, bool isActivatable)
    {
        _isRobotScene = isRobotScene;
        _isActivatable = isActivatable;
    }

    //public void AddToPartList(MachinePart part)
    //{
    //    MachineParts.Add(part);
    //}

    public void AddToSocketList(Socket socket)
    {
        Sockets.Add(socket);
    }

    //for all machine parts, "isActive" will be updated
    public void CheckAllParts()
    {
        bool isCorrect = true;

        foreach(var socket in Sockets)
        {
            if(!socket.CheckPart()) //if one part is inactive
            {
                isCorrect = false;
            }
        }

        _allCorrect = isCorrect;
        if (_allCorrect)
        {
            Debug.Log("AnalyzerManager: All parts are correct");
        }
        else
        {
            Debug.Log("AnalyzerManager: Not all parts are correct");
        }
        if(!_isRobotScene)
        {
            CheckedAllParts.Invoke();
        }
        
    }

    public void InsertSubstanceBall()
    {
        _substanceBallInserted = true;
        Debug.Log("Ball inserted.");

    }

    public void ActivateAnalyzer(bool isActivated)
    {
        _isActive = isActivated;
    }

    public void StartAnalyzer()
    {
        //if (_allCorrect & _substanceBallInserted)
        if(_allCorrect & _substanceBallInserted)
        {
            if(!_isActivatable || (_isActivatable & _isActive))
            {
                Debug.Log("Level completed.");
                SubstanceAnalyzedEvent.Invoke();
            }
        }
        else
        {
            Debug.Log("Failed: Substance Ball inserted = " + _substanceBallInserted + ", all parts correct= " + _allCorrect);

        }
    }

    public void SubscribeSubstanceAnalyzedEvent(Action method)
    {
        SubstanceAnalyzedEvent += method;
    }

    public void SubscribeCheckedAllParts(Action method)
    {
        CheckedAllParts += method;
    }

}
