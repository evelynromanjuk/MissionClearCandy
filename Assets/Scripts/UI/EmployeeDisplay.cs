using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EmployeeDisplay : MonoBehaviour
{
    public Employee Employee;
    public EmployeeEntry EmployeeEntry;

    private TMP_Text _buttonSubject;
    private Button _employeeButton;

    // Start is called before the first frame update
    void Start()
    {
        _employeeButton = this.GetComponent<Button>();
        _employeeButton.onClick.AddListener(ShowEmployee);

        _buttonSubject = _employeeButton.transform.GetChild(0).GetComponent<TMP_Text>();
        _buttonSubject.text = Employee.name;
    }

    private void ShowEmployee()
    {
        EmployeeEntry.SetEmployeeEntry(Employee.name, Employee.birthday, Employee.position, Employee.id, Employee.password, Employee.photo);
    }
}
