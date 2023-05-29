using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachinePartDisplay : MonoBehaviour
{
    public SecurityElement SecurityElement; //actually a machine part, but this ScriptableObject works for both
    public MachinePartEntry MachinePartEntry;
    public AnalyzerManager AnalyzerManager;
    public GameObject LaboratoryPanel;

    private Button _partButton;
    private Image _statusKnob;
    private bool _wasInitialized = false;

    void Awake()
    {
        _partButton = this.GetComponent<Button>();
        _statusKnob = this.GetComponent<Image>();
        _partButton.onClick.AddListener(ShowDetails);

        AnalyzerManager.SubscribeCheckedAllParts(UpdateKnobColor);
        _wasInitialized = true;
    }

    private void Start()
    {
        //The laboratory panel is active in the beginning so all status knobs can subscribe to AnalyzerManager, is deactivated again afterwards
        //if (LaboratoryPanel.activeInHierarchy)
        //{
        //    LaboratoryPanel.SetActive(false);
        //    Debug.Log("LaboratoryPanel was set to inactive");
        //}
    }

    public void ShowDetails()
    {
        MachinePartEntry.SetEntry(SecurityElement.ElementName, SecurityElement.Status, SecurityElement.InfoText);
    }

    private void UpdateKnobColor()
    {
        if(SecurityElement.IsActive)
        {
            _statusKnob.color = new Color32(0, 255, 0, 255);
        }
    }
}
