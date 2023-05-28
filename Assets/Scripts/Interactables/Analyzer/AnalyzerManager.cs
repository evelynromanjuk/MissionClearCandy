using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnalyzerManager : MonoBehaviour
{
    List<MachinePart> MachineParts = new List<MachinePart>();
    Action SubstanceAnalyzedEvent;

    private bool _allCorrect;
    private bool _substanceBallInserted;

    void Start()
    {
        _allCorrect = false;
        _substanceBallInserted = false;

    }

    public void SubscribeSubstanceAnalyzedEvent(Action method)
    {
        SubstanceAnalyzedEvent += method;
    }

    public void AddToList(MachinePart part)
    {
        MachineParts.Add(part);
    }

    public void CheckAllSockets()
    {
        bool isCorrect = true;
        foreach(var part in MachineParts)
        {
            if(!part.IsActive())
            {
                isCorrect = false;
                break;
            }
        }
        _allCorrect = isCorrect;
        if(_allCorrect)
        {
            Debug.Log("AnalyzerManager: All parts are correct");
        }
        else
        {
            Debug.Log("AnalyzerManager: Not all parts are correct");
        }
    }

    public void InsertSubstanceBall()
    {
        _substanceBallInserted = true;
        Debug.Log("Ball inserted.");

    }

    public void StartAnalyzer()
    {
        if (_allCorrect & _substanceBallInserted)
        {
            Debug.Log("Level completed.");
            SubstanceAnalyzedEvent.Invoke();
        }
        else
        {
            Debug.Log("Failed: Substance Ball inserted = " + _substanceBallInserted + ", all parts correct= " + _allCorrect);

        }
    }

}
