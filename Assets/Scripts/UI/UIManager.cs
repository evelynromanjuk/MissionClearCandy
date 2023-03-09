using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public PlayerInteract Player;

    [SerializeField]
    private GameObject FramePrefab;

    [SerializeField]
    private GameObject DataEntry;

    private GameObject _frameScanInfo;

    private bool isInstantiated = false;

    // Start is called before the first frame update
    void Start()
    {
        Player.Subscribe(OnScan);
    }

    private void OnScan(string[,] _scanData)
    {
        if (!isInstantiated)
        {
            InstantiateScanInformationFrame();
            PasteScanData(_scanData);
        }
    }

    private void InstantiateScanInformationFrame()
    {
        GameObject parent = GameObject.Find("Canvas_RobotHUD");
        _frameScanInfo = Instantiate(FramePrefab, parent.transform, false) as GameObject;
    }

    private void PasteScanData(string[,] _scanData)
    {
        GameObject parent = GameObject.Find("Canvas_RobotHUD");

        for (int i = 0; i < _scanData.GetLength(0); i++)
        {
            GameObject Body = _frameScanInfo.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
            GameObject NewEntry = Instantiate(DataEntry, Body.transform, false) as GameObject;

            NewEntry.transform.GetChild(0).GetComponent<TMP_Text>().text = _scanData[i, 0];
            NewEntry.transform.GetChild(1).GetComponent<TMP_Text>().text = _scanData[i, 1];
        }
    }
    

}
