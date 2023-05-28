using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New SecurityElement", menuName = "SecurityElement")]
public class SecurityElement : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _activeStatus;
    [SerializeField] private string _inactiveStatus;
    [SerializeField] private string _activeInfoText;
    [SerializeField] private string _inactiveInfoText;

    private string _status;
    private string _infoText;
    private bool _isActive;

    private void OnEnable()
    {
        _isActive = false;
        _status = _inactiveStatus;
        _infoText = _inactiveInfoText;
    }

    public void SetActive(bool IsNowActive)
    {
        _isActive = IsNowActive;
        ChangeInfoText();
    }

    void ChangeInfoText()
    {
        if(_isActive)
        {
            _infoText = _activeInfoText;
            _status = _activeStatus;
        }
        else
        {
            _infoText = _inactiveInfoText;
            _status = _inactiveStatus;
        }
    }

    public string ElementName
    {
        get { return _name;  }
    }

    public bool IsActive
    {
        get { return _isActive;  }
    }

    public string Status
    {
        get { return _status;  }
    }

    public string InfoText
    {
        get { return _infoText;  }
    }


}
