using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FontChanger : MonoBehaviour
{
    private TMP_Text buttonText;

    private Color textColorHover = new Color(0f, 0f, 0f, 1.0f);

    private Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("number of children: " + this.gameObject.transform.childCount);
        //Debug.Log("hello");
        if (this.gameObject.transform.childCount > 0 && this.gameObject.transform.GetChild(0) != null)
        {
            Debug.Log("Child detected");
            buttonText = this.gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
            defaultColor = buttonText.color;
        }
        else
        {
            //Debug.Log("no child");
        }
        //Debug.Log("bye");
        
    }

    public void printButtonText()
    {
        Debug.Log(buttonText.text);
    }

    public void changeTextColorOnMouseEnter()
    {
        buttonText.color = textColorHover;
        Debug.Log("mouse enter");
    }

    public void changeTextColorOnMouseExit()
    {
        buttonText.color = defaultColor;
        Debug.Log("mouse exit");
    }
}
