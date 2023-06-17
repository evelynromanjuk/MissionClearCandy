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
    private bool _isConnected; //connection restored when substance ejected
    private bool _isLocked;

    private void OnEnable()
    {
        _isActive = false;
        _isConnected = false;
        _isLocked = true;
        _status = _inactiveStatus;
        _infoText = _inactiveInfoText;
    }

    public void SetActive(bool IsNowActive)
    {
        _isActive = IsNowActive;
        ChangeInfoTextMachine();
    }

    public void SetConnection(bool isConnected)
    {
        _isConnected = isConnected;
        Debug.Log("Is Connected? " + _isConnected);
        ChangeInfoTextSecurity();
    }

    public void SetLocked (bool isLocked)
    {
        _isLocked = isLocked;
        Debug.Log("IsLocked? " + _isLocked);
        ChangeInfoTextSecurity();
    }

    void ChangeInfoTextSecurity()
    {
        //Door connection
        if(_isConnected)
        {
            _infoText = _activeInfoText;
            Debug.Log("Set Info Text to active: " + _infoText);
        }
        else
        {
            _infoText = _inactiveInfoText;
            Debug.Log("Set Info Text to inactive: " + _infoText);
        }

        //Door locked
        if (_isLocked)
        {
            _status = _inactiveStatus;
        }
        else
        {
            _status = _activeStatus;
        }
    }

    void ChangeInfoTextMachine()
    {
        //Machine part status
        if (_isActive)
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

    public bool IsConnected
    {
        get { return _isConnected; }
    }

    public bool IsLocked
    {
        get { return _isLocked; }
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
