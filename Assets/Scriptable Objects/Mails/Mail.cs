using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mail", menuName = "Mail")]
public class Mail : ScriptableObject
{
    public string senderAdress;
    public string receiverAdress;
    public string subject;
    public string date;
    public string content;

}
