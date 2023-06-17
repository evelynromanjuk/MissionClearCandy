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
    private Color32 _green = new Color32(0, 255, 0, 255);
    private Color32 _red = new Color32(255, 0, 0, 255);


    // Start is called before the first frame update
    void Start()
    {
        _elementButton = this.GetComponent<Button>();
        _elementButton.onClick.AddListener(ShowDetails);

        _statusKnob = this.GetComponent<Image>();
    }

    public void ChangeKnobColor()
    {
        if(_statusKnob == null)
        {
            _statusKnob = this.GetComponent<Image>();
        }
        
        if (SecurityElement.IsConnected)
        {
            _statusKnob.color = _green;
        }
        else
        {
            _statusKnob.color = _red;
        }
        //SecurityElementEntry.SetEntry(SecurityElement.ElementName, SecurityElement.Status, SecurityElement.InfoText);
    }

    public void ShowDetails()
    {
        SecurityElementEntry.SetEntry(SecurityElement.ElementName, SecurityElement.Status, SecurityElement.InfoText);
    }

    public void ActivateLockButton()
    {
        SecurityElementEntry.ActivateLockButton();
    }
}
