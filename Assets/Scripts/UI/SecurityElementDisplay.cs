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
    }

    void ShowDetails()
    {
        Debug.Log("RoomControl Button clicked");
        if(SecurityElement.IsActive)
        {
            _statusKnob.color = new Color32(0, 255, 0, 100);
            Debug.Log("Changed knob color");
        }
        SecurityElementEntry.SetEntry(SecurityElement.ElementName, SecurityElement.Status, SecurityElement.InfoText);
    }
}
