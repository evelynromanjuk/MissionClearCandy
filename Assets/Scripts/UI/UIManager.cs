using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public PlayerInteract Player;
    public PlayerLook PlayerLook;
    public FrameScanInfo FrameScanInfo;
    public GameObject FrameBackMenu;

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

        if(FrameScanInfo.gameObject.activeInHierarchy == false)
        {
            ShowCursor(true);
            FrameBackMenu.gameObject.SetActive(true);
            PlayerLook.EnableLook(false);
        }
        else
        {
            FrameScanInfo.gameObject.SetActive(false);
        }
        
    }

    private void OnScan(string[,] _scanData)
    {
        if (!FrameScanInfo) return;
        FrameScanInfo.PasteScanData(_scanData);
        FrameScanInfo.gameObject.SetActive(true);
    }

    public void ShowCursor(bool isVisible)
    {
        if(isVisible)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}

