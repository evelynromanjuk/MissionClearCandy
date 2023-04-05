using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public PlayerInteract Player;
    public FrameScanInfo FrameScanInfo;

    Action<bool> ScanInfoInstantiatedEvent;

    // Start is called before the first frame update
    void Start()
    {
        Player.SubscribeObjectScanned(OnScan);
        Player.SubscribeReturn(OnReturn);
    }

    public void Subscribe(Action<bool> method)
    {
        ScanInfoInstantiatedEvent += method;
    }

    private void OnReturn()
    {
        if (!FrameScanInfo) return;
        FrameScanInfo.gameObject.SetActive(false);
    }

    private void OnScan(string[,] _scanData)
    {
        if (!FrameScanInfo) return;
        FrameScanInfo.PasteScanData(_scanData);
        FrameScanInfo.gameObject.SetActive(true);
    }
}
