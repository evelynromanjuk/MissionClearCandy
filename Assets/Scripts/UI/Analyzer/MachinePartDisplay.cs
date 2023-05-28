using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachinePartDisplay : MonoBehaviour
{
    public SecurityElement SecurityElement; //actually a machine part, but this ScriptableObject works for both
    public MachinePartEntry MachinePartEntry;

    private Button _partButton;
    private Image _statusKnob;

    // Start is called before the first frame update
    void Start()
    {
        _partButton = this.GetComponent<Button>();
        _partButton.onClick.AddListener(ShowDetails);

        _statusKnob = this.GetComponent<Image>();
    }

    public void ShowDetails()
    {
        if (SecurityElement.IsActive)
        {
            // TODO: Status knob color! Seems to be null right now
            _statusKnob.color = new Color32(0, 255, 0, 100);
            Debug.Log("Changed knob color");
        }
        MachinePartEntry.SetEntry(SecurityElement.ElementName, SecurityElement.Status, SecurityElement.InfoText);
    }
}
