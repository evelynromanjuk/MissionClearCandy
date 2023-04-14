using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EmployeeEntry : MonoBehaviour
{
    public TMP_Text Name;
    public TMP_Text Birthday;
    public TMP_Text Position;
    public TMP_Text ID;
    public TMP_Text Password;
    public Image Photo;

    public void SetEmployeeEntry(string name, string birthday, string position, string id, string password, Sprite photo)
    {

        Name.text = name;
        Birthday.text = birthday;
        Position.text = position;
        ID.text = id;
        Password.text = password;
        Photo.sprite = photo;

        this.gameObject.SetActive(true);
    }
}
