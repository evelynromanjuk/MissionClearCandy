using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MailDisplay : MonoBehaviour
{

    public Mail mail;
    private TMP_Text buttonSubject;

    private Button mailButton;
    public MailEntry MailEntry;

    // Start is called before the first frame update
    void Start()
    {

        mailButton = this.GetComponent<Button>();
        mailButton.onClick.AddListener(printMail);

        buttonSubject = mailButton.transform.GetChild(0).GetComponent<TMP_Text>();
        buttonSubject.text = mail.subject;
    }

    public void printMail()
    {
        MailEntry.SetMailEntry(mail.subject, mail.date, mail.senderAdress, mail.receiverAdress, mail.content);
        Debug.Log("Mail Subject of Button clicked: " + mail.subject);
    }
}
