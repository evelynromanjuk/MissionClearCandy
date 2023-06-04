using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ImageViewer : MonoBehaviour
{
    public TMP_Text Title;
    public Image Image;

    //public TMP_Text NewTitle;
    //public Image NewImage;

    public void SetImage(FileImage fileImage)
    {
        Title.text = fileImage.Title;
        Image.sprite = fileImage.Image;
    }
}
