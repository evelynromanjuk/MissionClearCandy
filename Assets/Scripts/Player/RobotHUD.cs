using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RobotHUD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;

    public TMP_Text NewInfo;

    private PlayerInteract PlayerInteract;
    private bool _newInfoShown = false;

    private void Start()
    {
        PlayerInteract = GetComponent<PlayerInteract>();
        PlayerInteract.SubscribeObjectScanned(ShowNewInfo);
    }

    // Update is called once per frame
    public void UpdateScannedObjectName(string scannedObjectName)
    {
        promptText.text = scannedObjectName;
    }

    void ShowNewInfo(string[,] data)
    {
        if(!_newInfoShown)
        {
            NewInfo.gameObject.SetActive(true);
            _newInfoShown = true;
        }
    }
}
