using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnalyzerManager : MonoBehaviour
{
    [SerializeField] private CheckSocket _socketChip;
    [SerializeField] private CheckSocket _socketKabel1;
    [SerializeField] private CheckSocket _socketKabel2;
    [SerializeField] private CheckSocket _socketZahnrad;
    [SerializeField] private CheckSocket _socketKolben;

    Dictionary<int, bool> Sockets;

    Action<Dictionary<int, bool>> SocketsCheckedEvent;
    Action SubstanceAnalyzedEvent;

    private bool _allCorrect;
    private bool _substanceBallInserted;

    void Start()
    {
        _allCorrect = false;
        _substanceBallInserted = false;

        Sockets = new Dictionary<int, bool>();
        Sockets.Add(1, false);
        //Sockets.Add(2, false);
        //Sockets.Add(3, false);
        //Sockets.Add(4, false);
        //Sockets.Add(5, false);

        _socketChip.SubscribePartInsertedEvent(LogInsertedPart);
        //_socketKabel1.SubscribePartInsertedEvent(LogInsertedPart);
        //_socketKabel2.SubscribePartInsertedEvent(LogInsertedPart);
        //_socketZahnrad.SubscribePartInsertedEvent(LogInsertedPart);
        //_socketKolben.SubscribePartInsertedEvent(LogInsertedPart);
    }

    public void SubscribeSubstanceAnalyzedEvent(Action method)
    {
        SubstanceAnalyzedEvent += method;
    }

    public void SubscribeSocketsCheckedEvent(Action<Dictionary<int, bool>> method)
    {
        SocketsCheckedEvent += method;
    }

    void LogInsertedPart(int socketId, bool partIsCorrect)
    {
        if (partIsCorrect)
        {
            Sockets[socketId] = true;
        }
        else
        {
            Sockets[socketId] = false;
        }

        CheckAllSockets();
    }

    void CheckAllSockets()
    {
        foreach (KeyValuePair<int, bool> entry in Sockets)
        {
            if (entry.Value == false)
            {
                _allCorrect = false;
                break;
            }
            else
            {
                _allCorrect = true;
            }
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

    public void CheckSockets()
    {
        foreach (KeyValuePair<int, bool> entry in Sockets)
        {
            Debug.Log("Socket #" + entry.Key + ": " + entry.Value);
        }

        //SocketsCheckedEvent.Invoke(Sockets); // TODO: add back later
    }
}
