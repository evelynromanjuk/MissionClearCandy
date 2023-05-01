using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstanceMachine : MonoBehaviour
{
    public GameObject HorizontalScanner;
    public GameObject VerticalScanner;
    public Transform Parent;
    public KeypadManager KeypadManager;
    public CMScreenManager CMScreenManager;

    private GameObject _scannerObject;

    private bool _scannerIsVertical;

   public void SetScreenOrientation(bool isVertical)
    {
        _scannerIsVertical = isVertical;
        InitializeScannerPrefab();
    }

    private void InitializeScannerPrefab()
    {
        _scannerObject = _scannerIsVertical ? VerticalScanner : HorizontalScanner; //short for if-else-statement

        GameObject s = Instantiate(_scannerObject);
        s.transform.SetParent(Parent, false);
        if(_scannerIsVertical)
        {
            s.transform.localPosition = new Vector3(-1.25f, 1.15f, 0.35f);
            s.transform.localRotation = Quaternion.Euler(0.0f, -45.0f, 0.0f);
        }
        else
        {
            s.transform.localPosition = new Vector3(-1.351f, 0.99f, 0.1f);
        }
        

        Scanner scanner = _scannerObject.GetComponent<Scanner>();

        KeypadManager.SetScanner(scanner);
        CMScreenManager.SetScanner(scanner);

    }
}
