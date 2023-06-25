using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnalyzerManager : MonoBehaviour
{
    public PlayerInteract PlayerInteract;
    List<Socket> Sockets = new List<Socket>();

    static Action CheckedAllParts;
    Action SubstanceAnalyzedEvent;
    Action<bool> CheckedCorrect;

    private bool _isRobotScene;

    private bool _isActivatable = false;
    private bool _isActive = false;
    private bool _allCorrect;

    void Start()
    {
        _allCorrect = false;

        if(_isActivatable & _isRobotScene)
        {
            PlayerInteract.SubscribeAnalyzerActivated(ActivateAnalyzer);
        }
    }

    public void InitializeAnalyzer(bool isRobotScene, bool isActivatable)
    {
        _isRobotScene = isRobotScene;
        _isActivatable = isActivatable;

        Debug.Log("Is robot scene? = " + _isRobotScene);
        Debug.Log("Is activatable? = " + _isActivatable);
    }


    public void AddToSocketList(Socket socket)
    {
        Sockets.Add(socket);
    }

    //for all machine parts, "isActive" will be updated
    public void CheckAllParts()
    {
        if(!_isActivatable || (_isActivatable & _isActive))
        {
            bool isCorrect = true;

            foreach (var socket in Sockets)
            {
                if (!socket.CheckPart()) //if one part is inactive
                {
                    isCorrect = false;
                    Debug.Log("Not all parts are correct");
                    AudioManager.Instance.Play("ButtonPushFailed");
                }
            }

            _allCorrect = isCorrect;
            if(_allCorrect)
            {
                AudioManager.Instance.Play("EngineRunning");
            }

            if(_isRobotScene && _allCorrect)
            {
                Debug.Log("All parts are correct");
                CheckedCorrect.Invoke(_allCorrect);
            }

            if (!_isRobotScene)
            {
                CheckedAllParts.Invoke();
            }
        }
    }

    public void ActivateAnalyzer(bool isActivated)
    {
        _isActive = isActivated;
        Debug.Log("Analyzer activated? " + _isActive);
    }

    public void StartAnalyzer()
    {
        //if (_allCorrect & _substanceBallInserted)
        if(_allCorrect)
        {
            if(!_isActivatable || (_isActivatable & _isActive))
            {
                Debug.Log("Level completed.");
                SubstanceAnalyzedEvent.Invoke();
                AudioManager.Instance.Stop("EngineRunning");
                AudioManager.Instance.Play("AnalyzerStart");
            }
        }
        else
        {
            Debug.Log("Failed: all parts correct= " + _allCorrect);
            AudioManager.Instance.Play("ButtonPushFailed");

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

    public void SubscribeCheckedCorrect(Action<bool> method)
    {
        CheckedCorrect += method;
    }

}
