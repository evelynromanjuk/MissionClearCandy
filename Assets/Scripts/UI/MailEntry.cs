using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MailEntry : MonoBehaviour
{
    public TMP_Text Subject;
    public TMP_Text Date;
    public TMP_Text Sender;
    public TMP_Text Receiver;
    public TMP_Text ContentMail;

    public void SetMailEntry(string subject, string date, string sender, string receiver, string mail)
    {

        Subject.text = subject;
        Date.text = date;
        Sender.text = sender;
        Receiver.text = receiver;
        ContentMail.text = mail;

        this.gameObject.SetActive(true);
    }
}
