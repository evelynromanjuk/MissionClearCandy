using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FontChanger : MonoBehaviour
{
    [SerializeField]
    private bool ButtonHoverReversed;

    private TMP_Text buttonText;
    private Color textColorHover = new Color32(0, 0, 0, 255);
    private Color defaultColor = new Color32(8, 255, 0, 255);

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.transform.childCount > 0 && this.gameObject.transform.GetChild(0) != null)
        {
            buttonText = this.gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
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

    private void ChangeFontBlack()
    {
        if (this.gameObject.GetComponent<Button>().interactable == true)
        {
            buttonText.color = textColorHover;
        }
    }

    private void ChangeFontGreen()
    {
        if (this.gameObject.GetComponent<Button>().interactable == true)
        {
            buttonText.color = defaultColor;
        }
    }
}
