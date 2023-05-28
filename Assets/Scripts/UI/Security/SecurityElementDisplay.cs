using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecurityElementDisplay : MonoBehaviour
{
    public SecurityElement SecurityElement;
    public SecurityElementEntry SecurityElementEntry;

    private Button _elementButton;
    private Image _statusKnob;


    // Start is called before the first frame update
    void Start()
    {
        _elementButton = this.GetComponent<Button>();
        _elementButton.onClick.AddListener(ShowDetails);


        _statusKnob = this.GetComponent<Image>();
        if(_statusKnob == null)
        {
            Debug.Log("statusknob is null");
        }
    }

    public void ShowDetails()
    {
        Debug.Log("RoomControl Button clicked");
        if(SecurityElement.IsActive)
        {
            // TODO: Status knob color! Seems to be null right now
            //_statusKnob.color = new Color32(0, 255, 0, 100);
            Debug.Log("Changed knob color");
        }
        SecurityElementEntry.SetEntry(SecurityElement.ElementName, SecurityElement.Status, SecurityElement.InfoText);
    }

    public void ActivateLockButton()
    {
        SecurityElementEntry.ActivateLockButton();
    }
}
