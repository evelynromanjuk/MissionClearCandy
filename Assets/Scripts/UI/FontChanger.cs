using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FontChanger : MonoBehaviour
{
    private TMP_Text buttonText;

    private Color textColorHover = new Color(0f, 0f, 0f, 1.0f);

    private Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.transform.childCount > 0 && this.gameObject.transform.GetChild(0) != null)
        {
            buttonText = this.gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
            defaultColor = buttonText.color;
        }
    }

    public void printButtonText()
    {
        Debug.Log(buttonText.text);
    }

    public void changeTextColorOnMouseEnter()
    {
        if (this.gameObject.GetComponent<Button>().interactable == true)
        {
            buttonText.color = textColorHover;
        }
    }

    public void changeTextColorOnMouseExit()
    {
        if (this.gameObject.GetComponent<Button>().interactable == true)
        {
            buttonText.color = defaultColor;
        }
    }
}
