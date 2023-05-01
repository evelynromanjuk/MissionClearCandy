using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstanceMachine : MonoBehaviour
{
    public GameObject HorizontalScanner;
    public GameObject VerticalScanner;
    public Transform Parent;

    private GameObject _scanner;

    private bool _scannerIsVertical;

   public void SetScreenOrientation(bool isVertical)
    {
        _scannerIsVertical = isVertical;
    }

    private void InitializeScannerPrefab()
    {
        _scanner = _scannerIsVertical ? VerticalScanner : HorizontalScanner; //short for if-else-statement

        GameObject s = Instantiate(_scanner);
        s.transform.SetParent(Parent, false);
        s.transform.localPosition = new Vector3(-1.25f, 1.15f, 0.35f);
        s.transform.localRotation = Quaternion.Euler(0.0f, -45.0f, 0.0f);

    }
}
