using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Employee", menuName = "Employee")]
public class Employee : ScannableData
{ 
    public new string name;
    public string position;
    public string id;
    public string birthday;
    public string password;
    //public Sprite photo;
    
    private string[,] _cardData;

    public override void CreateArray()
    {
        _cardData = new string[,] { { "objectType", objectType }, {"name", name}, {"position", position}, {"birthday", birthday}, {"password", password} };
    }

    public override string[,] GetScanData { get => _cardData; }

    public override void Reset()
    {
        objectType = "employee ID card";
    }
}
