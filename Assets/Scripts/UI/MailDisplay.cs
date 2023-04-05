using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MailDisplay : MonoBehaviour
{

    public Mail mail;
    private TMP_Text buttonSubject;
    public Image contentImage;

    private Button mailButton;
    //private GameObject contentImageText;
    public MailEntry MailEntry;

    // Start is called before the first frame update
    void Start()
    {

        mailButton = this.GetComponent<Button>();
        mailButton.onClick.AddListener(printMail);

        buttonSubject = mailButton.transform.GetChild(0).GetComponent<TMP_Text>();
        buttonSubject.text = mail.subject;

        //contentImageText = contentImage.transform.GetChild(0).gameObject;
        
    }

    public void printMail()
    {
        MailEntry.SetMailEntry(mail.subject, mail.date, mail.senderAdress, mail.receiverAdress, mail.content);

        //if (!contentImageText.activeInHierarchy)
        //{
        //    contentImageText.SetActive(true);
        //}

        //TMP_Text contentSubject = contentImageText.transform.GetChild(0).GetComponent<TMP_Text>();
        //TMP_Text contentDate = contentImageText.transform.GetChild(1).GetComponent<TMP_Text>();
        //TMP_Text contentFrom = contentImageText.transform.GetChild(2).GetComponent<TMP_Text>();
        //TMP_Text contentTo = contentImageText.transform.GetChild(3).GetComponent<TMP_Text>();
        //TMP_Text contentMail = contentImageText.transform.GetChild(4).GetComponent<TMP_Text>();

        //contentSubject.text = mail.subject;
        //contentDate.text = mail.date;
        //contentFrom.text = mail.senderAdress;
        //contentTo.text = mail.receiverAdress;
        //contentMail.text = mail.content;

        Debug.Log("Mail Subject of Button clicked: " + mail.subject);
    }
}
